using ChikaraBackend.Model;
using Dapper;
using MySql.Data.MySqlClient;

namespace ChikaraBackend.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MySQLConfiguration _connectionString;
        public UserRepository(MySQLConfiguration connectionString)
        {

            _connectionString = connectionString;

        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }



        public Task<IEnumerable<User>> GetAllUsers()
        {
            var db = dbConnection();

            var sql = @"CALL getAllUsers();";

            return db.QueryAsync<User>(sql, new { });
            //throw new NotImplementedException();
        }

        public async Task<User> GetDetails(int id)
        {
            var db = dbConnection();

            var sql = @"CALL getUser( @id )";

            return await db.QueryFirstOrDefaultAsync<User>(sql, new { id });
            //throw new NotImplementedException();
        }

        public async Task<bool> InsertUser(User user)
        {

            var db = dbConnection();

            var sql = @"CALL insertUsers(@user_username, @user_password, @user_FK_user_create, @user_FK_user_update, @user_date_create, @user_date_update, @user_FK_states)";

            var result = await db.ExecuteAsync(sql, new { user.user_username, user.user_password, user.user_FK_user_create, user.user_FK_user_update, user.user_date_create, user.user_date_update, user.user_FK_states});

            return result > 0;

            //throw new NotImplementedException("No se ha actualizado");
        }

        public async Task<bool> UpdateUser(User user)
        {
            var db = dbConnection();

            var sql = @"CALL updateUser@user_username, @user_password, @user_FK_user_create, @user_FK_user_update, @user_date_create, @user_date_update, @user_FK_states, @user_PK)";

            var result = await db.ExecuteAsync(sql, new { user.user_PK, user.user_username, user.user_password, user.user_FK_user_create, user.user_FK_user_update, user.user_date_create, user.user_date_update, user.user_FK_states });

            return result > 0;
            //throw new NotImplementedException();
        }
        public async Task<bool> DeleteUser(User user)
        {
            var db = dbConnection();

            var sql = @"CALL deleteUser(@user_PK)";

            var result = await db.ExecuteAsync(sql, new { user.user_PK });

            return result > 0;


            //throw new NotImplementedException();
        }
    }
}
