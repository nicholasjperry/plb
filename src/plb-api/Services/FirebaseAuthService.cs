// Firebase SDK for .NET
using FirebaseAdmin;

// Auth-related operations
using FirebaseAdmin.Auth;

// Authentication via service account credentials
using Google.Apis.Auth.OAuth2;

namespace plb_api.Services

{
    // Singleton service
    public class FirebaseAuthService
    {
        // Reference to Firebase Authentication methods
        private readonly FirebaseAuth _firebaseAuth;

        public FirebaseAuthService()
        {
            // Check if Firebase hasn't been initialized
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
            // TODO: still using this function?
            // Validate token from frontend
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
    public async Task<UserRecord> GetUser(string uid)
        {
            // Retrieve user details from Firebase
            return await _firebaseAuth.GetUserAsync(uid);
        }

    public async Task<UserRecord> CreateUser(string email, string password, string username)
        {
            var user = new UserRecordArgs { 
                Email = email, 
                Password = password,
                DisplayName = username,
            };

            return await _firebaseAuth.CreateUserAsync(user);
        }
    }

}
