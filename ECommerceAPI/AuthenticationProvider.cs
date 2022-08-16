namespace ECommerceAPI
{
    public class AuthenticationProvider
    {
        private readonly ILogger<AuthenticationProvider> _logger;
        private readonly Dictionary<Guid, KeyValuePair<int, DateTime>> _tokenHandler;
        private readonly int _tokenLifeTime;

        public AuthenticationProvider(ILogger<AuthenticationProvider> logger)
        {
            _logger = logger;
            _tokenHandler = new Dictionary<Guid, KeyValuePair<int, DateTime>>();
            _tokenLifeTime = 180; // should be Configured
        }

        public Guid CreateToken(int userId)
        {
            var token = Guid.NewGuid();
            _tokenHandler.Add(token, new KeyValuePair<int, DateTime>(userId, DateTime.Now));
            return token;
        }

        public int GetUserId(Guid token)
        {
            if (_tokenHandler.TryGetValue(token, out var timeSinceLastAccess))
            {
                if (timeSinceLastAccess.Value.AddSeconds(_tokenLifeTime) >= DateTime.Now) // Token still invalid
                {
                    // Should change KeyValuePair to a new solution
                    _tokenHandler[token] = new KeyValuePair<int, DateTime>(timeSinceLastAccess.Key, DateTime.Now); 
                    return timeSinceLastAccess.Key;
                }
                // if not valid
                _tokenHandler.Remove(token);
                _logger.LogWarning("Token lifetime ran out");
            }
            else
            {
                _logger.LogWarning("Token doesn't exist");
            }

            return -1;
        }
    }
}
