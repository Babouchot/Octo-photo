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
        string bdConec = "Server=YXXX;Database=DBMiniProjet;Integrated Security=true;";

        public void addImage(string ID, int idAlbum, byte[] image)
        {            
            try
            {
                // connexion au serveur
                string connectionStr = bdConec;

                // creation des object SqlConnection, SqlCommand et DataReader 
                connexion = new SqlConnection(connectionStr);
                connexion.Open();

                // construit la requête
                SqlCommand ajoutImage = new SqlCommand("INSERT INTO Photo (blob, size, idAlbum, nomPhoto) " +
                    "VALUES(@blob, @size, @idAlbum, @ID)", connexion);
                ajoutImage.Parameters.Add("@blob", SqlDbType.Image, image.Length).Value = image;
                ajoutImage.Parameters.Add("@size", SqlDbType.Int).Value = image.Length;
                ajoutImage.Parameters.Add("@idAlbum", SqlDbType.Int).Value = idAlbum;
                ajoutImage.Parameters.Add("@ID", SqlDbType.NChar).Value = ID.ToCharArray(0, ID.Length);
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
                string connectionStr = bdConec;

                // creation des object SqlConnection, SqlCommand et DataReader 
                connexion = new SqlConnection(connectionStr);
                connexion.Open();

                // construit la requête 
                SqlCommand getImage = new SqlCommand(
                    "SELECT nomPhoto,size, blob " +
                    "FROM Photo " +
                    "WHERE nomPhoto = @nomPhoto", connexion);
                getImage.Parameters.Add("@nomPhoto", SqlDbType.VarChar, imageID.Length).Value =
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

        public String[] getAlbum(int albumID)
        {
            String[] listImage = null;

            try
            {
                // connexion au serveur
                string connectionStr = bdConec;

                // creation des object SqlConnection, SqlCommand et DataReader 
                connexion = new SqlConnection(connectionStr);
                connexion.Open();

                // construit la requête 
                SqlCommand getAlbum = new SqlCommand(
                    "SELECT idAlbum, nomPhoto " +
                    "FROM Photo " +
                    "WHERE idAlbum = @idAlbum", connexion);
                getAlbum.Parameters.Add("@idAlbum", SqlDbType.Int).Value = albumID;
                // exécution de la requête et création du reader
                SqlDataReader myReader = getAlbum.ExecuteReader(CommandBehavior.SequentialAccess);
                int e = 0;
                List<String> listTmp = new List<String>();

                while (myReader.Read())
                {
                    char[] buf = new char[20];
                    myReader.GetChars(1,0,buf, 0, 20);
                    String temp = new String(buf);
                    listTmp.Add(temp);
                }
                listImage = new String[listTmp.Count];
                foreach (String s in listTmp)
                {
                    listImage[e] = s;
                    e++;
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
            return listImage;
        }

        public String getNomAlbum(int albumID)
        {
            String nomAlbum = null;

            try
            {
                // connexion au serveur
                string connectionStr = bdConec;

                // creation des object SqlConnection, SqlCommand et DataReader 
                connexion = new SqlConnection(connectionStr);
                connexion.Open();

                // construit la requête 
                SqlCommand getAlbum = new SqlCommand(
                    "SELECT nomAlbum " +
                    "FROM Album " +
                    "WHERE idAlbum = @idAlbum", connexion);
                getAlbum.Parameters.Add("@idAlbum", SqlDbType.Int).Value = albumID;
                // exécution de la requête et création du reader
                SqlDataReader myReader = getAlbum.ExecuteReader(CommandBehavior.SequentialAccess);

                if (myReader.Read())
                {
                    char[] buf = new char[20];
                    myReader.GetChars(0, 0, buf, 0, 20);
                    nomAlbum = new String(buf);
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
            return nomAlbum;
        }

        public int[] getUserAlbum(int userID)
        {
            int[] listeAlbum = null;

            try
            {
                // connexion au serveur
                string connectionStr = bdConec;

                // creation des object SqlConnection, SqlCommand et DataReader 
                connexion = new SqlConnection(connectionStr);
                connexion.Open();

                // construit la requête 
                SqlCommand getUserAlbum = new SqlCommand(
                    "SELECT idAlbum, idUtilisateur " +
                    "FROM Album " +
                    "WHERE idUtilisateur = @idUtilisateur", connexion);
                getUserAlbum.Parameters.Add("@idUtilisateur", SqlDbType.Int).Value = userID;

                SqlDataReader myReader = getUserAlbum.ExecuteReader(CommandBehavior.SequentialAccess);
                int e = 0;
                List<int> listTmp = new List<int>();

                while (myReader.Read())
                {
                    listTmp.Add(myReader.GetInt32(0));
                }

                listeAlbum = new int[listTmp.Count];
                foreach (int i in listTmp)
                {
                    listeAlbum[e] = i;
                    e++;
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
            return listeAlbum;
        }

        public void deleteUser(int id)
        {
            try
            {
                // connexion au serveur
                string connectionStr = bdConec;

                // creation des object SqlConnection, SqlCommand et DataReader 
                connexion = new SqlConnection(connectionStr);
                connexion.Open();

                // construit la requête 
                SqlCommand deleteUser = new SqlCommand(
                    "DELETE FROM Utilisateur WHERE idUtilisateur = @idUtilisateur", connexion);
                deleteUser.Parameters.Add("@idUtilisateur", SqlDbType.Int).Value = id;
                deleteUser.ExecuteNonQuery();
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

        public void deleteAlbum(int id)
        {
            try
            {
                // connexion au serveur
                string connectionStr = bdConec;

                // creation des object SqlConnection, SqlCommand
                connexion = new SqlConnection(connectionStr);
                connexion.Open();

                // construit la requête 
                SqlCommand deleteAlbum = new SqlCommand(
                    "DELETE FROM Album WHERE idAlbum = @idAlbum", connexion);
                deleteAlbum.Parameters.Add("@idAlbum", SqlDbType.Int).Value = id;
                deleteAlbum.ExecuteNonQuery();
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

        public void createAlbum(String nomAlbum, int idUser)
        {
            try
            {
                // connexion au serveur
                string connectionStr = bdConec;

                // creation des object SqlConnection, SqlCommand
                connexion = new SqlConnection(connectionStr);
                connexion.Open();

                // construit la requête 
                SqlCommand createAlbum = new SqlCommand(
                    "INSERT INTO Album (idUtilisateur, nomAlbum) VALUES (@idUtilisateur, @nomAlbum)", connexion);
                createAlbum.Parameters.Add("@idUtilisateur", SqlDbType.Int).Value = idUser;
                createAlbum.Parameters.Add("@nomAlbum", SqlDbType.NChar, nomAlbum.Length).Value = nomAlbum;
                createAlbum.ExecuteNonQuery();
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

        public void createUser(String userLastname, String userFirstname, String password)
        {
            try
            {
                // connexion au serveur
                string connectionStr = bdConec;

                // creation des object SqlConnection, SqlCommand
                connexion = new SqlConnection(connectionStr);
                connexion.Open();

                // construit la requête 
                SqlCommand createUser = new SqlCommand(
                    "INSERT INTO Utilisateur (nom, prenom, password) VALUES (@nom, @prenom, @password)", connexion);
                createUser.Parameters.Add("@nom", SqlDbType.NChar, userLastname.Length).Value = userLastname;
                createUser.Parameters.Add("@prenom", SqlDbType.NChar, userFirstname.Length).Value = userFirstname;
                createUser.Parameters.Add("@password", SqlDbType.NChar, password.Length).Value = password;
                createUser.ExecuteNonQuery();
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

        public void deletePhotoInAlbum(int id)
        {
            try
            {
                // connexion au serveur
                string connectionStr = bdConec;

                // creation des object SqlConnection, SqlCommand
                connexion = new SqlConnection(connectionStr);
                connexion.Open();

                // construit la requête                 
                SqlCommand deletePhotoInAlbum = new SqlCommand(
                    "DELETE FROM Photo WHERE idAlbum = @idAlbum", connexion);
                deletePhotoInAlbum.Parameters.Add("@idAlbum", SqlDbType.Int).Value = id;

                deletePhotoInAlbum.ExecuteNonQuery();
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

        public void deletePhoto(int id)
        {
            try
            {
                // connexion au serveur
                string connectionStr = bdConec;

                // creation des object SqlConnection, SqlCommand
                connexion = new SqlConnection(connectionStr);
                connexion.Open();

                // construit la requête 
                SqlCommand deletePhoto = new SqlCommand(
                    "DELETE FROM Photo WHERE id = @id", connexion);
                deletePhoto.Parameters.Add("@id", SqlDbType.Int).Value = id;
                deletePhoto.ExecuteNonQuery();
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

        public void deletePhoto(String nom)
        {
            try
            {
                // connexion au serveur
                string connectionStr = bdConec;

                // creation des object SqlConnection, SqlCommand
                connexion = new SqlConnection(connectionStr);
                connexion.Open();

                // construit la requête 
                SqlCommand deletePhoto = new SqlCommand(
                    "DELETE FROM Photo WHERE nomPhoto = @nomPhoto", connexion);
                deletePhoto.Parameters.Add("@nomPhoto", SqlDbType.NChar, nom.Length).Value = nom;
                deletePhoto.ExecuteNonQuery();
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
    }
}