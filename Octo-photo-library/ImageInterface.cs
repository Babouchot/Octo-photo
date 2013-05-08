﻿using System;
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
        string bdConec = "Server=MAUREILL;Database=DBMiniProjet;Integrated Security=true;";

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

        // récupération d'une image de la base à l'aide d'un DataReader
        public byte[][] getAlbum(int albumID)
        {
            byte[][] imageBlob = null;
            byte[] blob = null;

            try
            {
                // connexion au serveur
                string connectionStr = bdConec;

                // creation des object SqlConnection, SqlCommand et DataReader 
                connexion = new SqlConnection(connectionStr);
                connexion.Open();

                // construit la requête 
                SqlCommand getAlbum = new SqlCommand(
                    "SELECT size, blob, idAlbum " +
                    "FROM Photo" +
                    "WHERE idAlbum = @idAlbum", connexion);
                getAlbum.Parameters.Add("@idAlbum", SqlDbType.Int).Value =
                albumID;
                // exécution de la requête et création du reader
                SqlDataReader myReader =
                getAlbum.ExecuteReader(CommandBehavior.SequentialAccess);
                int e = 0;

                while (myReader.Read())
                {
                    // lit la taille du blob
                    int size = myReader.GetInt32(1);
                    blob = new byte[size];
                    // récupére le blob de la BDD et le copie dans la variable blob
                    myReader.GetBytes(2, 0, blob, 0, size);
                    //on ajoute au tableau de blob le blob courant
                    imageBlob[e] = blob;
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
            return imageBlob;
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
                    "SELECT idAlbum " +
                    "FROM Album" +
                    "WHERE idUtilisateur = @idUtilisateur", connexion);
                getUserAlbum.Parameters.Add("@idUtilisateur", SqlDbType.Int).Value = userID;
                int e = 0;
                // exécution de la requête et création du reader
                SqlDataReader myReader = getUserAlbum.ExecuteReader(CommandBehavior.SequentialAccess);

                while (myReader.Read())
                {
                    listeAlbum[e] = myReader.GetInt32(0);
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
    }
}