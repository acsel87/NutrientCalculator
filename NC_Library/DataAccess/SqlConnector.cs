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
                    foreach (FoodModel f in model.FoodList)
                    {
                        p.Add("@PlanId", model.Id);
                        p.Add("@RecipeId", null);
                        p.Add("@FoodId", f.Id);

                        connection.Execute("dbo.spPlanItems_Insert", p, commandType: CommandType.StoredProcedure);
                    }
                }

                if (model.RecipeList != null)
                {
                    p = new DynamicParameters();
                    foreach (RecipeModel r in model.RecipeList)
                    {
                        p.Add("@PlanId", model.Id);
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

                p = new DynamicParameters();
                foreach (FoodModel f in model.FoodList)
                {
                    p.Add("@RecipeId", model.Id);
                    p.Add("@FoodId", f.Id);

                    connection.Execute("dbo.spRecipeItems_Insert", p, commandType: CommandType.StoredProcedure);
                }
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
            throw new NotImplementedException();
        }

        public void UpdatePlan(PlanModel model)
        {
            throw new NotImplementedException();
        }

        public void UpdateRecipe(RecipeModel model)
        {
            throw new NotImplementedException();
        }

        public FoodModel ViewFood(FoodModel model)
        {
            throw new NotImplementedException();
        }

        public PlanModel ViewPlan(PlanModel model)
        {
            throw new NotImplementedException();
        }

        public RecipeModel ViewRecipe(RecipeModel model)
        {
            throw new NotImplementedException();
        }
    }
}
