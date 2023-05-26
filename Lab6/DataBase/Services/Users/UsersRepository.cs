namespace DataBase.Services.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        DbUser[] IUserRepository.Get()
        {
            return dbContext.Users.Where(u => !u.Isdeleted).ToArray(); 
        }

        public DbUser? Get(int id) {
            return dbContext.Users.Where(u => !u.Isdeleted).FirstOrDefault(u => u.Id == id);
        }

        void IUserRepository.Create(DbUser user)
        {
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
        }


        public void Update(DbUser user)
        {
            DbUser? dbUser = Get(user.Id);

            if (dbUser == null)
            {
                return;
            }

            dbUser.Login = user.Login;
           
            dbUser.UserName = user.UserName;

            dbContext.SaveChanges();
        }

        public void Delete(int id) 
        {
            DbUser? dbUser = Get(id); 
            if (dbUser == null) 
            { 
                return;
            }


            dbUser.Isdeleted=true; 
            dbContext.SaveChanges();
        }
    }
}
