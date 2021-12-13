using System;

namespace Collections
{
    public class User : IUser
    {


        public User(string fullName, string username, uint? age)
        {
            FullName = fullName;
            Username = username;
            Age = age;
        }

        public uint? Age { get; }

        public string FullName { get; }

        public string Username { get; }



        public bool IsAgeDefined => Age != null;


        protected bool Equals(User other)
        {
            return Age == other.Age && FullName == other.FullName && Username == other.Username;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((User) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Age, FullName, Username);
        }

        public override string ToString()
        {
            return "Fullname:" + this.FullName + " Username:" + this.Username + " Age:" + this.Age + "\n";
        }
    }
}
