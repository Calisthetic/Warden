namespace WebApiCoreWarden.Models.DataTransferObjects
{
    public partial class UserMessagesCount
    {
        private static WardenContext _context = new WardenContext();
        public UserMessagesCount(User user)
        {
            if (_context.Logs.AsEnumerable().Where(x => x.Message.Contains($"Сотрудник ИБ перешёл на страницу переписки с пользователем {user.UserId} из чёрного списка") == true).Count() == 0)
            {
                if (_context.BlockedUserMessages.Where(x => x.SendlerUserId == user.UserId).OrderByDescending(x => x.Time).Count() == 0)
                {
                    UncheckedMessagesCount = 0;
                    UserLastMessage = null;
                } 
                else
                {
                    UncheckedMessagesCount = _context.BlockedUserMessages.Where(x => x.SendlerUserId == user.UserId).Count();
                    UserLastMessage = _context.BlockedUserMessages.Where(x => x.SendlerUserId == user.UserId).OrderByDescending(x => x.Time).First();
                }
            }
            else
            {
                DateTime lastLogged = _context.Logs.AsEnumerable().Where(x => x.Message.Contains($"Сотрудник ИБ перешёл на страницу переписки с пользователем {user.UserId} из чёрного списка") == true).OrderByDescending(x => x.Logged).FirstOrDefault().Logged;
                UncheckedMessagesCount = _context.BlockedUserMessages.Where(x => x.Time > lastLogged && x.SendlerUserId == user.UserId).Count();
                UserLastMessage = _context.BlockedUserMessages.Where(x => x.SendlerUserId == user.UserId || x.DestinationUserId == user.UserId).OrderByDescending(x => x.Time).First();
            }
            SendlerUser = user;
        }
        public int UncheckedMessagesCount { get; set; }

        public BlockedUserMessage? UserLastMessage { get; set; }
        
        public User? SendlerUser { get; set; }
    }
}
