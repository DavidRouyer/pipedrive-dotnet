namespace Pipedrive
{
    public enum AuthenticationType
    {
        /// <summary>
        /// No credentials provided
        /// </summary>
        Anonymous,
        /// <summary>
        /// Credential for token based authentication
        /// </summary>
        ApiToken,
        /// <summary>
        /// Credential for Pipedrive App using signed JWT
        /// </summary>
        Bearer
    }
}
