using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;

namespace plb_api.Services

{
    public class FirebaseAuthService
    {
        private readonly FirebaseAuth _firebaseAuth;

        public FirebaseAuthService()
        {
            if (FirebaseApp.DefaultInstance == null)
            {
                FirebaseApp.Create(new AppOptions
                {
                    Credential = GoogleCredential.GetApplicationDefault()
                });
            }

            _firebaseAuth = FirebaseAuth.DefaultInstance;
        }
    public async Task<FirebaseToken?> VerifyIdToken(string idToken)
        {
            try
            {
                var decodedToken = await _firebaseAuth.VerifyIdTokenAsync(idToken);
                return decodedToken;
            }
            catch
            {
                return null;
            }
        }
    public async Task<UserRecord> GetUserByUidAsync(string uid)
        {
            return await _firebaseAuth.GetUserAsync(uid);
        }
    }
}
