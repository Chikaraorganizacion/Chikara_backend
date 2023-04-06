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

           /* var db = dbConnection();

            var sql = @"CALL insertUsers(@UserName, @Password, @UserCreated, @UserUpdated, @DateCreated, @DateUpdated, @State)";

            var result = await db.ExecuteAsync(sql, new { user.UserName, user.Password, user.UserCreated, user.UserUpdated, user.DateCreated, user.DateUpdated, user.State });

            return result > 0;*/
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateUser(User user)
        {
            /*var db = dbConnection();

            var sql = @"CALL updateUser(@UserName, @Password, @UserCreated, @UserUpdated, @DateCreated, @DateUpdated, @State, @id)";

            var result = await db.ExecuteAsync(sql, new { user.UserName, user.Password, user.UserCreated, user.UserUpdated, user.DateCreated, user.DateUpdated, user.State, user.Id });

            return result > 0;*/
            throw new NotImplementedException();
        }
        public Task<bool> DeleteUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
