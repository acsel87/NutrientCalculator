using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using NC_Library.Models;

namespace NC_Library.DataAccess
{
    public class SqlConnector : IDataConnection
    {
        private const string db = "Nutrients";

        public void CreateFood(FoodModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                var p = new DynamicParameters();
                p.Add("@Name", model.Name);
                p.Add("@IsCustom", Convert.ToInt32(model.IsCustom));
                p.Add("@Type", model.Type);
                p.Add("@Nutrient_List", model.Nutrient_List);                
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spFood_Insert", p, commandType: CommandType.StoredProcedure);

                model.Id = p.Get<int>("@id");
            }
        }

        public void CreatePlan(PlanModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                var p = new DynamicParameters();
                p.Add("@Name", model.Name);
                p.Add("@Amount", model.Amount);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spPlan_Insert", p, commandType: CommandType.StoredProcedure);

                model.Id = p.Get<int>("@id");

                if (model.FoodList != null)
                {
                    p = new DynamicParameters();
                    p.Add("@PlanId", model.Id);
                    foreach (FoodModel f in model.FoodList)
                    {                        
                        p.Add("@RecipeId", null);
                        p.Add("@FoodId", f.Id);

                        connection.Execute("dbo.spPlanItems_Insert", p, commandType: CommandType.StoredProcedure);
                    }
                }

                if (model.RecipeList != null)
                {
                    p = new DynamicParameters();
                    p.Add("@PlanId", model.Id);
                    foreach (RecipeModel r in model.RecipeList)
                    {                        
                        p.Add("@RecipeId", r.Id);
                        p.Add("@FoodId", null);

                        connection.Execute("dbo.spPlanItems_Insert", p, commandType: CommandType.StoredProcedure);
                    }
                }
            }
        }

        public void CreateRecipe(RecipeModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                var p = new DynamicParameters();
                p.Add("@Name", model.Name);
                p.Add("@Amount", model.Amount);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spRecipe_Insert", p, commandType: CommandType.StoredProcedure);

                model.Id = p.Get<int>("@id");

                if (model.FoodList != null)
                {
                    p = new DynamicParameters();
                    p.Add("@RecipeId", model.Id);
                    foreach (FoodModel f in model.FoodList)
                    {
                        p.Add("@FoodId", f.Id);

                        connection.Execute("dbo.spRecipeItems_Insert", p, commandType: CommandType.StoredProcedure);
                    }
                }
            }
        }

        public void DeleteFood(FoodModel model)
        {
            if (Convert.ToInt32(model.IsCustom) == 1)
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
                {
                    var p = new DynamicParameters();
                    p.Add("@Id", model.Id);

                    connection.Execute("dbo.spPlanItems_DeleteByFood", p, commandType: CommandType.StoredProcedure);

                    connection.Execute("dbo.spRecipeItems_DeleteByFood", p, commandType: CommandType.StoredProcedure);

                    connection.Execute("dbo.spFood_Delete", p, commandType: CommandType.StoredProcedure);
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Error: Only Custom food can be updated");
            }
        }

        public void DeletePlan(PlanModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                var p = new DynamicParameters();
                p.Add("@Id", model.Id);               

                connection.Execute("dbo.spPlanItems_Delete", p, commandType: CommandType.StoredProcedure);

                connection.Execute("dbo.spPlan_Delete", p, commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteRecipe(RecipeModel model)
        {            
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                var p = new DynamicParameters();
                p.Add("@Id", model.Id);

                connection.Execute("dbo.spPlanItems_DeleteByRecipe", p, commandType: CommandType.StoredProcedure);

                connection.Execute("dbo.spRecipeItems_Delete", p, commandType: CommandType.StoredProcedure);

                connection.Execute("dbo.spRecipe_Delete", p, commandType: CommandType.StoredProcedure);
            }            
        }

        public List<FoodModel> GetFood_All()
        {
            List<FoodModel> output;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                output = connection.Query<FoodModel>("dbo.spFood_GetAll").ToList();
            }

            return output;
        }

        public List<PlanModel> GetPlan_All()
        {
            List<PlanModel> output = new List<PlanModel>(); ;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                output = connection.Query<PlanModel>("dbo.spPlan_GetAll").ToList();

                foreach (PlanModel pm in output)
                {
                    var p = new DynamicParameters();                   
                    p.Add("@Id", pm.Id);

                    pm.FoodList = connection.Query<FoodModel>("dbo.spPlanItems_GetFood", p, commandType: CommandType.StoredProcedure).ToList();

                    List<RecipeModel> recipes = connection.Query<RecipeModel>("dbo.spPlanItems_GetRecipe", p, commandType: CommandType.StoredProcedure).ToList();
                    
                    foreach (RecipeModel r in recipes)
                    {
                        p = new DynamicParameters();
                        p.Add("@Id", r.Id);

                        r.FoodList = connection.Query<FoodModel>("dbo.spRecipeItems_GetFood", p, commandType: CommandType.StoredProcedure).ToList();
                    }

                    pm.RecipeList = recipes;
                }
            }

            return output;
        }

        public List<RecipeModel> GetRecipe_All()
        {
            List<RecipeModel> output = new List<RecipeModel>();            

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                output = connection.Query<RecipeModel>("dbo.spRecipe_GetAll").ToList();
                
                foreach (RecipeModel r in output)
                {
                    var p = new DynamicParameters();                   
                    p.Add("@Id", r.Id);

                    r.FoodList = connection.Query<FoodModel>("dbo.spRecipeItems_GetFood", p, commandType: CommandType.StoredProcedure).ToList();
                }    
            }            
            return output;
        }       

        public void UpdateFood(FoodModel model)
        {
            if (Convert.ToInt32(model.IsCustom) == 1)
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
                {
                    var p = new DynamicParameters();
                    p.Add("@Name", model.Name);
                    p.Add("@Type", model.Type);
                    p.Add("@Nutrient_List", model.Nutrient_List);
                    p.Add("@Id", model.Id);

                    connection.Execute("dbo.spFood_Update", p, commandType: CommandType.StoredProcedure);
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Error: Only Custom food can be deleted");
            }            
        }

        public void UpdatePlan(PlanModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                var p = new DynamicParameters();
                p.Add("@Name", model.Name);
                p.Add("@Amount", model.Amount);
                p.Add("@Id", model.Id);

                connection.Execute("dbo.spPlan_Update", p, commandType: CommandType.StoredProcedure);

                p = new DynamicParameters();
                p.Add("@PlanId", model.Id);

                connection.Execute("dbo.spPlanItems_Delete", p, commandType: CommandType.StoredProcedure);

                if (model.FoodList != null)
                {
                    foreach (FoodModel f in model.FoodList)
                    {
                        p.Add("@RecipeId", null);
                        p.Add("@FoodId", f.Id);

                        connection.Execute("dbo.spPlanItems_Insert", p, commandType: CommandType.StoredProcedure);
                    }
                }

                if (model.RecipeList != null)
                {                   
                    foreach (RecipeModel r in model.RecipeList)
                    {
                        p.Add("@RecipeId", r.Id);
                        p.Add("@FoodId", null);

                        connection.Execute("dbo.spPlanItems_Insert", p, commandType: CommandType.StoredProcedure);
                    }
                }
            }
        }

        public void UpdateRecipe(RecipeModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                var p = new DynamicParameters();
                p.Add("@Name", model.Name);
                p.Add("@Amount", model.Amount);                
                p.Add("@Id", model.Id);

                connection.Execute("dbo.spRecipe_Update", p, commandType: CommandType.StoredProcedure);

                p = new DynamicParameters();
                p.Add("@RecipeId", model.Id);

                connection.Execute("dbo.spRecipeItems_Delete", p, commandType: CommandType.StoredProcedure);

                if (model.FoodList != null)
                {
                    foreach (FoodModel f in model.FoodList)
                    {
                        p.Add("@FoodId", f.Id);

                        connection.Execute("dbo.spRecipeItems_Insert", p, commandType: CommandType.StoredProcedure);
                    }
                }
            }
        }

        public FoodModel ViewFood(FoodModel model)
        {
            if (model != null && model.Id != 0)
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
                {
                    var p = new DynamicParameters();
                    p.Add("@Id", model.Id);

                    model = connection.Query<FoodModel>("dbo.spFood_GetById", p, commandType: CommandType.StoredProcedure).First();
                }
            }           

            return model;
        }

        public PlanModel ViewPlan(PlanModel model)
        {
            if (model != null && model.Id != 0)
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
                {
                    var p = new DynamicParameters();
                    p.Add("@Id", model.Id);

                    model = connection.Query<PlanModel>("dbo.spPlan_GetById", p, commandType: CommandType.StoredProcedure).First();

                    model.FoodList = connection.Query<FoodModel>("dbo.spPlanItems_GetFood", p, commandType: CommandType.StoredProcedure).ToList();

                    model.RecipeList = connection.Query<RecipeModel>("dbo.spPlanItems_GetRecipe", p, commandType: CommandType.StoredProcedure).ToList();

                    foreach (RecipeModel r in model.RecipeList)
                    {
                        p = new DynamicParameters();
                        p.Add("@Id", r.Id);

                        r.FoodList = connection.Query<FoodModel>("dbo.spRecipeItems_GetFood", p, commandType: CommandType.StoredProcedure).ToList();
                    }
                } 
            }

            return model;
        }

        public RecipeModel ViewRecipe(RecipeModel model)
        {
            if (model != null && model.Id != 0)
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
                {
                    var p = new DynamicParameters();
                    p.Add("@Id", model.Id);

                    model = connection.Query<RecipeModel>("dbo.spRecipe_GetById", p, commandType: CommandType.StoredProcedure).First();

                    model.FoodList = connection.Query<FoodModel>("dbo.spRecipeItems_GetFood", p, commandType: CommandType.StoredProcedure).ToList();
                } 
            }

            return model;
        }
    }
}
