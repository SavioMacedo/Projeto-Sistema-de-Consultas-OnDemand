using System.Security.Claims;

namespace MVC.Extensoes
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// User ID
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static string Identificador(this ClaimsPrincipal user)
        {
            if (!user.Identity.IsAuthenticated)
                return null;

            ClaimsPrincipal currentUser = user;
            return currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

    }
}
