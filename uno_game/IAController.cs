using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uno_game
{
    static class IAController
    {
        static Card IAChooseCard()
        {
            return null;
        }

        static public void CreateMove(Card cardOnDeck, Card playedCard, bool useFull)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Constantin\\Documents\\GitHub\\uno\\uno_game\\Database.mdf;Integrated Security=True";

            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand cm = new SqlCommand("INSERT INTO [Table] ([CardOnStack], [CardPayed], [UseFull], [ColorOnStack], [ColorCardPlayer]) VALUES (@cardonstack, @cardplayed, @usefull, @colorsonstack, @colorscardplayer)", cn);

            SqlParameter cardOnstackParam = cm.Parameters.AddWithValue("@cardonstack", cardOnDeck.Number);
            SqlParameter playedCardParam = cm.Parameters.AddWithValue("@cardplayed", playedCard.Number);
            SqlParameter usefullParam = cm.Parameters.AddWithValue("@usefull", useFull);
            SqlParameter colorCardOnstackParam = cm.Parameters.AddWithValue("@colorsonstack", cardOnDeck.Color);
            SqlParameter ColorCardPlayerParam = cm.Parameters.AddWithValue("@colorscardplayer", playedCard.Color);

            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();
        }
    }
}
