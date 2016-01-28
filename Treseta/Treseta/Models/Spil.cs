using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Treseta.Models;

namespace Treseta.Models
{
    class Spil //mac grofe jedan
    {
        private List<Karta> spil = new List<Karta>();
        public Spil()
        {
            spil.Add(new Karta("tricaBastoni", Zvanje.bastoni, 10, 1, "https://lh3.googleusercontent.com/dd-FGx1J8W8tp2pjkW839ZtJbFhJiCxohGP-TtXJL-VtYiGwLhvYIRUgLPjrPJgDAUrA9A=s190"));
            spil.Add(new Karta("dujaBastoni", Zvanje.bastoni, 9, 1, "https://lh5.googleusercontent.com/awWSz-QY00nsCbcsyg3djucRnqv1Kw6j-IqH2roMlxbREu2OgMWS3tjXdcjE4yDGYk_xxw=s190"));
            spil.Add(new Karta("asBastoni", Zvanje.bastoni, 8, 3, "https://lh5.googleusercontent.com/_5qATuyKnexDRC8tAgZhZnzVbiPGidpSXpS-KVxDePHbPKsjOfPEQpX4fivsfd5kGG_JFA=s190"));
            spil.Add(new Karta("kraljBastoni", Zvanje.bastoni, 7, 1, "https://lh3.googleusercontent.com/vL87XHVnl1b_8bTQQ-XEEPyi3rc8r5Gr5uKQDhrE4lKKiC6ZJv1BElvX2jUSLx9k5lBmEA=w1325-h523"));
            spil.Add(new Karta("kavalBastoni", Zvanje.bastoni, 6, 1, "https://lh3.googleusercontent.com/TpoxC_Bpywi1JFirim7hWdDaRUtHCOB16eCmPiPJfzC0ECo9q-4p7K2SJJKEtWt90HkZtg=s190"));
            spil.Add(new Karta("fanatBastoni", Zvanje.bastoni, 5, 1, "https://lh4.googleusercontent.com/ttqau4fzSUzvA6-Uf0F8nouOp1o_sEdKNfZpdDHXm44x1oem4FzIid0L5GHgcmBgdTB8tw=s190"));
            spil.Add(new Karta("sedmicaBastoni", Zvanje.bastoni, 4, 0, "https://lh3.googleusercontent.com/B92lHtxbbgSr7oInMEFq8FJtzASaFppfaOSECRtnduz3Aw6wvsDLDGWh02I0jLZDxDA2Gw=s190"));
            spil.Add(new Karta("sesticaBastoni", Zvanje.bastoni, 3, 0, "https://lh5.googleusercontent.com/cBovE4ukAFjAb-lEhLkj7Y1D9_WiVCMNIqXFdQH6kHNI-HR4OPDfZeZloV7KMoL7jq3HHw=s190"));
            spil.Add(new Karta("peticaBastoni", Zvanje.bastoni, 2, 0, "https://lh6.googleusercontent.com/cYeIh9csfdfzq-YM1BwHo3808TN37g43QRFhB78gr0ZHXo2OCSLvAGrtPJKtXVAK4aiEWA=s190"));
            spil.Add(new Karta("cetvorkaBastoni", Zvanje.bastoni, 1, 0, "https://lh3.googleusercontent.com/cbs3oIweZdT7AlpgJNWM_RpKH4sOxkSxYtujcraZygpliWbKTNW-P3tEGMUChBRfkszLSA=s190"));
            spil.Add(new Karta("tricaSpade", Zvanje.spade, 10, 1, "https://lh6.googleusercontent.com/J8sM4tXSoXAbKK1y1qc5nXe_JgLrKj3azTlz73n355Qb5YLONCR-GlhkpsXb1xeH0Iw7oQ=s190"));
            spil.Add(new Karta("dujaSpade", Zvanje.spade, 9, 1, "https://lh5.googleusercontent.com/brIREfpLXca_inuaHCtWXteuW-QHrNOJY4k0Texbvav_NGLPKbDqpukUx7I_atCebAAZOg=s190"));
            spil.Add(new Karta("asSpade", Zvanje.spade, 8, 3, "https://lh5.googleusercontent.com/V3gjM9jf9rMBZ98eV7Y4YckiIy8Iz9AjqWHeGYo8dpS6Wz4kWGYVoABGcuKEs3_NA83Z8g=s190"));
            spil.Add(new Karta("kraljSpade", Zvanje.spade, 7, 1, "https://lh5.googleusercontent.com/Pop3mX4GNAGBDUwaQghmoACiUWWYbUZ7Ob526CAxByPl8WjcOAmIky0iP7koswgdRcydYA=s190"));
            spil.Add(new Karta("kavalSpade", Zvanje.spade, 6, 1, "https://lh4.googleusercontent.com/8afzggXCLsG3-2gKXbr_gg-uTv2ktGJ-vWgyStZ8-sGc56BtnIhVSFVq04qiBHcKgdpJ0Q=s190"));
            spil.Add(new Karta("fanatSpade", Zvanje.spade, 5, 1, "https://lh4.googleusercontent.com/GEqK5ATfNXwTKTmNvBjffrPNHHypPS5Th3wDLGArCEZxIEEe6n0saFKyEnDKSYoIBSBNTg=s190"));
            spil.Add(new Karta("sedmicaSpade", Zvanje.spade, 4, 0, "https://lh3.googleusercontent.com/6pjYuFDyimbEfi73mXZES2_k8sNMK1wCyMA5dsxcFiJN_1FKqsJWsvVOjptUYLJBLzHb9w=s190"));
            spil.Add(new Karta("sesticaSpade", Zvanje.spade, 3, 0, "https://lh6.googleusercontent.com/q39LgcTuAix13g8Vw3nJguEZWpXmrpPMl6BpLi-gwc_44L7LmHlWoFHUGnALd_YE6KvTKA=s190"));
            spil.Add(new Karta("peticaSpade", Zvanje.spade, 2, 0, "https://lh5.googleusercontent.com/ERfrWIsiKXtlfOnnpdx2i5JKLXs7jf3j97mK6QpvDm1LJKf92lJWQeXgWedo8Wrh2i2h-g=s190"));
            spil.Add(new Karta("cetvorkaSpade", Zvanje.spade, 1, 0, "https://lh5.googleusercontent.com/-ikwL38BsW37bHIALTQavq0ytt9hMSSyBzR1j2fqBcj_5BfJU7FJYjsWuz2sPw5CdpSYgA=s190"));
            spil.Add(new Karta("tricaKopi", Zvanje.kupe, 10, 1, "https://lh4.googleusercontent.com/SOeCk8GQ4-KFsvZPfTIyXSpqwdDrN0jA49j3zMfQHBLx0MLKDRfGHqwT490rfr1gesPJaw=s190"));
            spil.Add(new Karta("dujaKopi", Zvanje.kupe, 9, 1, "https://lh4.googleusercontent.com/5-WGhpbeuFgchkKP3UrWL8UMUBBrIip_IkHZm49u0aq2hW0Y_lGjl2xHY7jNYObXl-41Zg=s190"));
            spil.Add(new Karta("asKopi", Zvanje.kupe, 8, 3, "https://lh3.googleusercontent.com/Nb0OR4xAXJuh3bMYSRplhYDfkOg11x8DtWNmnpQVVVnDh649ehG2ptVKdQzlpmW6Au-I5w=s190"));
            spil.Add(new Karta("kraljKopi", Zvanje.kupe, 7, 1, "https://lh3.googleusercontent.com/-9UatLe6S7_gtyBCqKIUlBtZGeUESdSjrFNCNRrLHz73GByn0CU84-9aUuLwOyKXFmNPIA=s190"));
            spil.Add(new Karta("kavalKopi", Zvanje.kupe, 6, 1, "https://lh5.googleusercontent.com/4y8f_diK22ceXAyVZwXmBfW2LmdiH0VJss0pgNU4hxkI1Hckp4vKHJHSWNSUpCHzlYUJbA=s190"));
            spil.Add(new Karta("fanatKopi", Zvanje.kupe, 5, 1, "https://lh3.googleusercontent.com/WXrqMBnwwS560ZgpsRlGMKrXR8JuEZRFRvKAzrhkQlELdox1Zw7maHcq4hLIZfs98d_XOw=s190"));
            spil.Add(new Karta("sedmicaKopi", Zvanje.kupe, 4, 0, "https://lh3.googleusercontent.com/juovKfPAgLvmDNqzqWViQguqIhXunyoluACWCket9JyGEhj_cz9HhKSM3JsoVPwevLHxrQ=s190"));
            spil.Add(new Karta("sesticaKopi", Zvanje.kupe, 3, 0, "https://lh4.googleusercontent.com/e0Wtlvb90MQTOIf72jQVEOHXqP0RbZnx0lpzxeUdHW5fKbfEE7oWYp7Y6fV7wgfUwixy6Q=s190"));
            spil.Add(new Karta("peticaKopi", Zvanje.kupe, 2, 0, "https://lh3.googleusercontent.com/FWtWmcBJ7cuDS-0DmNe5uTv-pNfiRPoA5ZvPNOChH5MQJH44EKAapOGpa6zhEkt2hkDwJQ=s190"));
            spil.Add(new Karta("cetvorkaKopi", Zvanje.kupe, 1, 0, "https://lh4.googleusercontent.com/gz6Iaedh8XcckW2VnK8DjTUOeuiPl6oVIbSfl0liThm7J5FAJTsON2T278qQ3VyjtLO5_g=s190"));
            spil.Add(new Karta("tricaDinari", Zvanje.dinari, 10, 1, "https://lh6.googleusercontent.com/xowUX3BghOXt3sgeinN25fleoRUYeoQmUAi8ZElfULou_1hb0ZoggQjeXhORs0y5ELbnmA=s190"));
            spil.Add(new Karta("dujaDinari", Zvanje.dinari, 9, 1, "https://lh3.googleusercontent.com/xBEuxcKGc_068PZsR_1i2l0eAFhqh4iNKvWxCFSfvLBrunMPZrn7jP99dzIIYfkEnx-17Q=s190"));
            spil.Add(new Karta("asDinari", Zvanje.dinari, 8, 3, "https://lh6.googleusercontent.com/gqvZ2B94iQcOpZOmO4NnScS0JIeWHomBwIN3FSwV1WzASMkdb0jETgtyRwIlgIuzDkSAGg=s190"));
            spil.Add(new Karta("kraljDinari", Zvanje.dinari, 7, 1, "https://lh4.googleusercontent.com/1N4-_LUOppZexqau5axrm98FeRXFtq8Iuv5N9DXA5KhAQKGBgxf2CXaCepBBUltXY8vUAA=s190"));
            spil.Add(new Karta("kavalDinari", Zvanje.dinari, 6, 1, "https://lh6.googleusercontent.com/6LaN74JTCk1SCFJ6HbOcLweKucRbuxw1IHOzg7hclaTysdO-5eKKsAZNx-sWXrnduGu4gg=s190"));
            spil.Add(new Karta("fanatDinari", Zvanje.dinari, 5, 1, "https://lh6.googleusercontent.com/YwnfhLFh5VH6UOAo1x3uku_eUJRvTeQUsWYJxfuG78-SuvpGMG109-B_UQwedfIsbEKSsA=s190"));
            spil.Add(new Karta("sedmicaDinari", Zvanje.dinari, 4, 0, "https://lh6.googleusercontent.com/S1e5BGId7x7NarkuZVvUwfyA7xqygpUhGrgNqyNahu6TNfG_No7oMrNw4Pb30qP7_T7pKw=s190"));
            spil.Add(new Karta("sesticaDinari", Zvanje.dinari, 3, 0, "https://lh6.googleusercontent.com/mK3A4L56NPrDd_7jMQchUkmW-q9s1xj67PrcaYgVDgxlUH2fhWR3LuQOp7RsZcslqHdU6A=s190"));
            spil.Add(new Karta("peticaDinari", Zvanje.dinari, 2, 0, "https://lh4.googleusercontent.com/mWQWVWe10AFBuexJaV7y-9s5bnesLBAzU-r747aFz1xBSB3PItahNbqvtvwQwFMoC60ZVg=s190"));
            spil.Add(new Karta("cetvorkaDinari", Zvanje.dinari, 1, 0, "https://lh6.googleusercontent.com/U_nreqOybvnHbauWEFdzHP24Rv3BGAUOFpuAME2h2tPGjkwPajTq55ARNUSoovL_7oaWsQ=s190"));
        }
        /// <summary>
        /// funkcija za dohvat karata za igraca
        /// </summary>
        /// <returns> vrati listu Kartu </returns>
        public List<Karta> getDesteKarat()
        {
            List<Karta> ruka = new List<Karta>();
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                int indexKarte = rnd.Next(spil.Count);
                Karta karta = spil[indexKarte];
                spil.RemoveAt(indexKarte);
                ruka.Add(karta);
            }

            return ruka;
        }

        /// <summary>
        /// za dohvat jedne karte u igri s 2 igraca
        /// </summary>
        /// <returns>
        /// vrati Kartu</returns>
        public Karta getKarta()
        {
            Random rnd = new Random();
            int indexKarte = rnd.Next(spil.Count);
            if (spil.Count == 0)
                return null;
            Karta karta = spil[indexKarte];
            spil.RemoveAt(indexKarte);
            return karta;
        }
    }
}
