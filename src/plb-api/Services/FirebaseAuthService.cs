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
    }
}
