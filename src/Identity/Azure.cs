using Azure.Identity;

namespace Identity
{
    public static class Azure
    {
        public static ManagedIdentityCredential ManagedIdentityCredential()
        {
            return new ManagedIdentityCredential();
        }

    }
}
