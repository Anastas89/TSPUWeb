
using System.Xml.Linq;
namespace Lab2.folder_class
{
    public static class Repository
    {

        private static List<User> Users = new List<User>();//Приватное поле список пользователей


        public static User[] GetData() //Метод получения массива пользователей
        {
            return Users.ToArray();//преобразование в массив листа
        }

        public static User? GetData(int id)
        {
            for (int i = 0; i <= Users.Count - 1; i++)
            {
                if (Users[i].Id == id) return Users[i];// или Users.Id
            }

            return null;
        }


        public static void Add(User user)//Метод добавления пользователя;//При добавлении каждому новому пользователю (User) должен выставляться новый id.
        {


            user.Id = Users.Count;
            Users.Add(user);

        }


        public static void Delete(int id)//Метод удаления пользователя по id;//Добавить проверку на наличие пользователя с таким id.
        {
            User? user = GetData(id);
            if (user == null)
            {
                return;
            }

            Users.Remove(user);
        }


        public static void Update(User user, int id) //Метод изменения пользователя по id//Добавить проверку на наличие пользователя с таким id. Редактировать можно только UserName и Login.
        {
            User? userInList = GetData(id);
            if (userInList == null)
            {
                return;
            }

            userInList.UserName = user.UserName;
            userInList.Login = user.Login;
        }

    }
}