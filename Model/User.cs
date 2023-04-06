namespace ChikaraBackend.Model
{
    public class User
    {
        /*public int Id { get; set; }

        public string? UserName { get; set; }

        public string? Password { get; set; }

        public int? UserCreated { get; set; }

        public int? UserUpdated { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }

        public int? State { get; set; }*/

        public int User_PK { get; set; }

        public string? user_username { get; set; }

        public string? user_password { get; set; }

        public int? user_FK_user_create { get; set; }

        public int? user_FK_user_update { get; set; }

        public DateTime? user_date_create { get; set; }

        public DateTime? user_date_update { get; set; }

        public int? user_FK_states { get; set; }
    }
}
