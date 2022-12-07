namespace Day6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] chars = DayInput.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                IEnumerable<char> seq = chars.Take(new Range(i, i+4));
                if (seq.Count() == seq.Distinct().Count())
                {
                    Console.WriteLine(i + 4);
                    break;
                }
            }

            for (int i = 0; i < chars.Length; i++)
            {
                IEnumerable<char> seq = chars.Take(new Range(i, i + 14));
                if (seq.Count() == seq.Distinct().Count())
                {
                    Console.WriteLine(i + 14);
                    break;
                }
            }
        }
        
        private static string DayInput = "dvgdvvbpbtbhbdhbhmmmcctmcmccggtrgghnhmnnqffpcprrqssnhsnhnshhsrsqqhchcdcfcqqcncrrzpppmzpzzhjzzzvrvnnpbpzzswzwswnngjgjgcjcfcllhffjbfjfhhppvnppfmfcmmcnnmnfnzfnzffphpnnnsvswvvnwnfntftjftfvvztzqzhzddttjpjbpphhlnnwgnwggdmmczclczzqddlcdldrlrccfflwwgqwwrjwrwzrrsdrrfssddcmmvrvlvhvfhfzhzbhbzzdmdvvsppwswmwdwjjzmzhhvghgthghvvtcthcttgsttpqpbbhthppzznntpnttshtshthhwrrgbbjzbjblblzbllcblcblbvvqfqqnjqqhfhftftwfftvvmddgzzmdzmdmtttttqmqmnqmqpmqpqqjlldpllfvlffjdfjjvlvjjjjbsjbjnnhmnhnrrwtrrfvvtppwmmpnnjbnjjcncjcttrcrjjlqjljccpzccvqvzzscctgccsmmnznhzhnnjggmjgmgjgtgtlgglhhrlhhrvhvrvtvvlvvwmmrjjzqqbzqqtgtzgttmgggwpgwgbwggwwprwwvswszznczncnccjnccjdjdjssqmmgcmcjmmhwhswhwdwrddtccmzmjmsmrmrddhrhhqbbspbsppqvqmvqmmclcddzjzvvslsffdhhqgqrqjrqjqjrrmpmrppcjpjffwhfwwppqvvzjzqqtftgfghgpglgnglldlvvwzwmmfzzhzmzhhswhhnvhvphpmphphrrwwfccmgmqgmmzgmgngznnzbzttjwttgngzzdndffwhfwhhlmllwqlwwgfgfpfnnldnldndbdcdddmbdmbbdpbpwbpptrrpggtrtrnttsmmcrmmlhltlgttblttbhttjzzvnnsbsqbqwbbtwtmtbbcjcljjslscswwglgqlgqgmmcpctcrttprpjjfvjfjqqljlvjljnnfhhfzhzmhmghhjnhjjbppmqqwlwswwgbbzszspzsppcscvvnhndhdwdmdrdssqrqdqsddnbnpplqppjbjdbdqdcccffsnntzntnmnlnbbrzzzvgvvqttbbzpbzpzdpdvppjmjpjbbdrbbgwgffzpzzjddmldlwwjdwwscwcfccnznmmfttvvmpmvpmvmcvmmjmwjwbbwqwjjzqjzjbbjqbjqqqthhsssmrsshvvprvvwccjlcctwwmgwgpwgpgcpptrppjppltlhthctttfptppwgpwprpbbqzbzznssfcsffbnnndffqmmqwmmpvvpvdppjqqttfpttjccbnbddvtdvddlsstjtccphchsswbbrqqgtqgqpqjqnjjvccwscwssjwjttqvtvmtmjjghghccpnpsplslmmfjfjtffgtgrtrftfhttpsttzzmhmllwqwhhnffdpffwbwnnbrrfbrrnjrjlljqqnjqnqqwlqqbbbtvvwgvgbgddpwdwvdwvdvvwzvwwtzwttppnttqccjtjrttqbbprpsrpssfjsffmdfmfbmbggjhggcjgcgvvjqqbhbllhrlhlclzzplpqqdtddrhhfssdvsvrrscsjjnwjjfpjfffcbfcfmmlpmphhhlpltptcpttppfssppgwppjgjnnblbhbtbrbgbpplnlvlsvlvwvwpptmtsswzswsnscsfcsfsfggzhghvvgbbfddgbbrmrtrqtthvhzhzthtbtjjcljjlcllzglzzdszdzjzjfzzzblbslbljjdnndvvnwnqnwqqscscmczcwwvrrlclttbtdtvddbrddvllnppvpmvmbbvfvttfcttggwgffrfwwwpwcpchppcrrgprgprgrjgjdgdgvddzndzdbzzswsvvtgtccrrnggbwggpjpnnsjjwfjjqfqvffrrhdrrsfrfjjfzfdzzqfqwbztszjqtttfdqvzmznzjlsjnwdthtwdtfslgdmgfpwsqcsqdhnsnsmghttfvlzqgspzdtlstdmthzftwmnqrznldpmwqbtthggjwcgjjmbpqgrnwspggjvrlcmtvpchmqhlwwtswqgpdjpbznqnssqhdjzgbjnfmgssrvnmmcvvhgmcvqbfdhgrhnqqzdmttmdzwgtprzqhplwnhhmlrvcbwpllqprtltdvqrwhvwzvlqsvfqsfjwmrnzlqpdgfpmtfdczqdnfjjbjmrdnffcmtwlzcmvnwmlpmqhvggdhptnzlvzwzwjbcszsnzgpwncfgvzfgbzwclvrbmllzpltzwjrftmppsfwhvvvhvqjtstnnczgtdbmpjjsscbdwplftgcgmtrnrnzplzhghrqgdtjwntwfstjwqjjrlhtwhnfqwfqgsjptjfpsrbnvvlgsltnvtfvscttwvrfzblzmfmnfrlrnzrrzhclggtntpjbbcphdvrfhnrtzvdmwbwgbftgzwlcqztghdhdmzwlmjbgptfnnzbmwsnzlzcpprqzmbbdsplmhpgmzthqcsfjcnfbfvsdsqzfvfcnpgqsvpgwsdbgjmsglrwmfjfpddczwvgdppfmrtszbtfdwbmlmzhqvvwmvlzvjfpffjnhwwhssfjnbzlqwqvjbjbhfntmhgswntdpbzlwwfbdbhrfhzfjsjbtlrqhlnrpfbwtpmrfvbhlmmsgtvcmrqmdpwvhqfqpgmfgnfrbvprhprtnpzjcnltndfsvjgndwblhwphtpsmnczgbtpwdvjsrctjbvbfslvslzlwbtstqvgcrqmfphwztpjqdmvcjpjqmjbdndfpzwsfwplchsmqwwbggptjdtztszmpfwgfwnqpdwfcpgrrhmfglsctjllflfltbcfvcpfcnqbwrvzmcmjpwptgsrlbrdchngwsdstfmcbrqvdsvvbnppdmnfwcgvpjjzqwcpvqfncvqlsfnjzprvhpgqscshqwsttdrsmqjfwlhcwlvnzvgvclqfjdgctvsrbwzflcldmrwlfhbgdtstqsqlblndnpgqlfbjzslcpcwvdwdffshhrzvhqwdsdmwtmtvcnrhmstvrnscppmbpmjbfjhljmsjnbjlhjhmnmcvvfgbdrblwbzrcctrjwjjwjtgnfjhhqbsmdjvdrdjtjbscfrsljnvqjlgjwqrvfmdttsvqjwdbswdtcfqsrpbvzrbsdqlqfjlrgcwzbqtqrpsrfcmbzcvjngcsmvqlbnghllcqcztbtvdrfcmpgfdprghsmbjvzbdnrdqnjdzslclgdsqglvpvcjpzqfwztlssljtmcdfcqdnqzwcttvpqfdpvzlhjfvvsgphgqrmzppvnjznqmdzfnfztjppstjfwddftcpcjnssznqbrvlvrzfhbvsjrwghttwlwfrptsvsrwfnvjtthwrppbngbgqvbsdgcrjcwjjljcwptrvgmbjpjtdbmhmzcfhzbsbrmzhdsrjbbmnwbsntpffdrrlgcrcgbcfwvlpmrzvsmvpjthtdjdvcspdsdvshlrwzcqnjmcnrgzbqzhfzbmtrvzzmjwbnjggtrtgcsnrmzbtjzgdmffdntspdhgnvgrmpbtnsspcqhsrvppjbrmdbggjbftnnbrgdsmdscqthdzflldfnplqccthpwccsfsnstttwztqnmnfshntqngmcndbsbftmgnhhwjvhchdfqzzgpdnfgvnjzjzfdzvsvtdqqcftrvmdcszcwpfrbcsmlqqfprrjgncwcvcngmrnwntcvzzlnwrhrznnldslhqdscbgsrqnvnmdtqvlttwqljmvbpbfldtbgzhvwzghnhwrwdqphhhgjpnmtlcmvfbdffnsvcswtmffzsrvczbntfpdsmwbqphvvcflpwgsrmjhrljlvzdgrcwpfphmvtwqwhjmrvmjzjlzlbflhzrdrzcdwhblpqwjljbvprddtvnccmchgctncwbpnmlqppfmhwchvjvpmblqhccfhlprdrczdfhmnsqhddbqlppgsnvhhfrwhqhfdpvsfcvzbqhgswtmnpmzrwsvnmztnqwdrhllssmgtzbztsprpsj";
    }
}