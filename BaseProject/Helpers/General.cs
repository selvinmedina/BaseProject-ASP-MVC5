
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace PasteleriaShadday.Helpers
{
    public static class General
    {
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
        }

        // Hacer facilmente el retorno de la fecha
        public static string FechaRetorno(DateTime fecha) =>
            (fecha.Year + "/" + fecha.Month.ToString("d2") + "/" + fecha.Day.ToString("d2")).ToString();

        // Hacer facilmente la fecha modifica de cada registro
        public static string FechaModifica(DateTime? fecha) =>
            fecha is null ? "No modificado" : FechaRetorno(fecha.Value);

        // Hacer facilmene el usuario modifica
        public static string UsuarioModifica(int? usuario, string nombreUsuario) =>
            usuario is null ? "No modificado" : nombreUsuario;

        // Crear un nombre unico con el parametro de la cantidad de caracteres del nombre
        public static string CrateUniqueName(int length)
        {
            string _allowedChars = "abcdefghijkmnpqrstuvwxyzABCDEFGHJKLMNPQRSTUVWXYZ";
            Byte[] randomBytes = new Byte[length];
            char[] chars = new char[length];
            int allowedCharCount = _allowedChars.Length;

            for (int i = 0; i < length; i++)
            {
                Random randomObj = new Random();
                randomObj.NextBytes(randomBytes);
                chars[i] = _allowedChars[(int)randomBytes[i] % allowedCharCount];
            }

            return new string(chars);
        }

        // Crear nombre unico para una imagen
        public static string CrateUniqueImageName(int length, string imageName)
        {
            return CrateUniqueName(10) + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(imageName);
        }
    }

    public static class CollectionExtensions
    {
        public static IQueryable<TSource> WhereIf<TSource>(
            this IQueryable<TSource> source,
            bool condition,
            Expression<Func<TSource, bool>> predicate)
        {
            if (condition)
                return source.Where(predicate);
            else
                return source;
        }
    }

    // Subir una imagen
    public class UploadImage
    {
        // El mensaje de error o exito que se enviara a la vista
        private string ErrorMessage { get; set; } = "Se ha guardado éxitosamente";

        // El tamaño del archivo
        public decimal filesize { get; set; }

        // Método para validar una imagen
        /*
         image: La imagen que se subió del servidor
         nombreOriginal: Si fue editado entonces posiblemente tenga un nombre
        */
        public (string, int) ValidationImage(HttpPostedFileBase image, string nombreOriginal)
        {
            try
            {
                // Si hay un nombre original entonces que retorne un mensaje de éxito, pero que no suba la imagen
                if (image == null && nombreOriginal != null && nombreOriginal != "")
                {
                    return (ErrorMessage, 3);
                }

                // Array de los tipos soportados para ina imagen
                string[] supportedTypes = new[] { "image/png", "image/jpeg", "image/jpg", "image/gif" };

                // Validar que sea el tipo soportado
                if (!supportedTypes.Contains(image.ContentType))
                {
                    ErrorMessage = "La extensión del archivo no es válida - Solo se admiten archivos PNG/JPEG/JPG/GIF";
                    return (ErrorMessage, 2);
                }

                // Si la imagen es más grande que el tamaño máximo, el tamaño es de MB
                else if (image.ContentLength > ((filesize * (1000) * 1024)))
                {
                    ErrorMessage = "El tamaño máximo del archivo debe ser " + filesize + "MB";
                    return (ErrorMessage, 2);
                }
                else
                {
                    // retornar que se puede subir la imagen, y un mensaje de éxito
                    return (ErrorMessage, 1);
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = "No ha subido una imagen, contacte al administrador si esto es un error.";
                return (ErrorMessage, 2);
            }
        }
    }
}