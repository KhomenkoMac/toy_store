namespace BuisnessLogic
{
    public class Profile
    {
        public int ProfileId { get; }
        public User User { get; }
        public Profile(int profileId, User user)
        {
            ProfileId = profileId;
            User = user;
        }
    }
}
