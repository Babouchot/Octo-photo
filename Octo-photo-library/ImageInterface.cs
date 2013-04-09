using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Octo_photo_library
{
    public class ImageInterface
    {
        SqlConnection connexion;

        public void addImage(String imageID, byte[] image)
        {
            
            try
            {
                // connexion au serveur
                string connectionStr = "Server=157.169.102.43/YXXX/user\\SQLEXPRESS;Database=DBMiniProjet;Integrated Security=true;";
                string queryStr = "SELECT * from Etudiant";

                // creation des object SqlConnection, SqlCommand et DataReader 
                connexion = new SqlConnection(connectionStr);
                connexion.Open();

                // construit la requête
                SqlCommand ajoutImage = new SqlCommand("INSERT INTO Image (id, blob, size) " +
                    "VALUES(@id, @Blob, @size)", connexion);
                ajoutImage.Parameters.Add("@id", SqlDbType.VarChar, imageID.Length).Value = imageID;
                ajoutImage.Parameters.Add("@Blob", SqlDbType.Image, image.Length).Value = image;
                ajoutImage.Parameters.Add("@size", SqlDbType.Int).Value = image.Length;

                // execution de la requête
                ajoutImage.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur :" + e.Message);
            }
            finally
            {
                // dans tous les cas on ferme la connexion
                connexion.Close();
            }
        }

        // récupération d'une image de la base à l'aide d'un DataReader
        public byte[] getImage(String imageID)
        {
            byte[] blob = null;
            try
            {
                // connexion au serveur
                connexion.Open();
                // construit la requête 
                SqlCommand getImage = new SqlCommand(
                    "SELECT id,size, blob " +
                    "FROM Image " +
                    "WHERE id = @id", connexion);
                getImage.Parameters.Add("@id", SqlDbType.VarChar, imageID.Length).Value =
                imageID;
                // exécution de la requête et création du reader
                SqlDataReader myReader =
                getImage.ExecuteReader(CommandBehavior.SequentialAccess);
                if (myReader.Read())
                {
                    // lit la taille du blob
                    int size = myReader.GetInt32(1);
                    blob = new byte[size];
                    // récupére le blob de la BDD et le copie dans la variable blob
                    myReader.GetBytes(2, 0, blob, 0, size);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur :" + e.Message);
            }
            finally
            {
                // dans tous les cas on ferme la connexion
                connexion.Close();
            }
            return blob;
        }
    }
}