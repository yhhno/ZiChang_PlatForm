using System;

public class MoneyChange
{
    public MoneyChange()
    {
        //
        // TODO: ÔÚ´Ë´¦Ìí¼Ó¹¹Ôìº¯ÊýÂß¼­
        //
    }
    public string ConvertToGig(double amount)
    {
        string m_str, m_int, m_dec;
        int m_pos, m_len;
        m_str = System.Convert.ToString(amount);
        m_len = m_str.Length;
        m_pos = m_str.IndexOf('.', 0);
        m_dec = "00";
        if (m_pos == -1)
            m_int = m_str;
        else
        {
            m_int = m_str.Substring(0, m_pos);
            m_dec = m_str.Substring(m_pos + 1, m_len - m_pos - 1);
            m_dec = m_dec.PadRight(2, '0');
            m_dec = m_dec.Substring(0, 2);
        }

        m_int = m_int.PadLeft(12, '0');

        m_str = "";
       
        if (m_int.Substring(0, 4) != "0000")
        {
            m_str += ConvertTo9999(m_int.Substring(0, 4)) + "ÒÚ";
        }

        if (m_int.Substring(4, 4) != "0000")
        {
            m_str += ConvertTo9999(m_int.Substring(4, 4)) + "Íò";
        }
        if (m_int.Substring(8, 4) != "0000")
        {
            m_str += ConvertTo9999(m_int.Substring(8, 4)) + "Ô²";
        }

        if (m_dec != "00")
        {
            m_str += ConvertDec(m_dec);
        }
        else
        {
            m_str += "Õû";
        }
        
        return m_str;

    }
    private string ConvertTo9999(string m_part)
    {
        string m_str;
        int m_val, m_tmp;

        m_str = "";
        m_val = (int)System.Convert.ToInt32(m_part, 10);
        m_tmp = (int)m_val / 1000;
        switch (m_tmp)
        {
            case 1:
                m_str = "Ò¼Çª";
                break;
            case 2:
                m_str = "·¡Çª";
                break;
            case 3:
                m_str = "ÈþÇª";
                break;
            case 4:
                m_str = "ËÁÇª";
                break;
            case 5:
                m_str = "ÎéÇª";
                break;
            case 6:
                m_str = "Â½Çª";
                break;
            case 7:
                m_str = "ÆâÇª";
                break;
            case 8:
                m_str = "°ÆÇª";
                break;
            case 9:
                m_str = "¾ÁÇª";
                break;
            default:
                break;
        }

        m_val = m_val - (m_tmp * 1000);
        m_tmp = (int)m_val / 100;

        switch (m_tmp)
        {
            case 1:
                m_str += "Ò¼°Û";
                break;
            case 2:
                m_str += "·¡°Û";
                break;
            case 3:
                m_str += "Èþ°Û";
                break;
            case 4:
                m_str += "ËÁ°Û";
                break;
            case 5:
                m_str += "Îé°Û";
                break;
            case 6:
                m_str += "Â½°Û";
                break;
            case 7:
                m_str += "Æâ°Û";
                break;
            case 8:
                m_str += "°Æ°Û";
                break;
            case 9:
                m_str += "¾Á°Û";
                break;
            default:
                break;
        }
        m_val = m_val - (m_tmp * 100);
        m_tmp = (int)m_val / 10;

        switch (m_tmp)
        {
            case 1:
                m_str += "Ò¼Ê°";
                break;
            case 2:
                m_str += "·¡Ê°";
                break;
            case 3:
                m_str += "ÈþÊ°";
                break;
            case 4:
                m_str += "ËÁÊ°";
                break;
            case 5:
                m_str += "ÎéÊ°";
                break;
            case 6:
                m_str += "Â½Ê°";
                break;
            case 7:
                m_str += "ÆâÊ°";
                break;
            case 8:
                m_str += "°ÆÊ°";
                break;
            case 9:
                m_str += "¾ÁÊ°";
                break;
            default:
                break;
        }

        m_val = m_val - (m_tmp * 10);
        m_tmp = (int)m_val % 10;

        switch (m_tmp)
        {
            case 1:
                m_str += "Ò¼";
                break;
            case 2:
                m_str += "·¡";
                break;
            case 3:
                m_str += "Èþ";
                break;
            case 4:
                m_str += "ËÁ";
                break;
            case 5:
                m_str += "Îé";
                break;
            case 6:
                m_str += "Â½";
                break;
            case 7:
                m_str += "Æâ";
                break;
            case 8:
                m_str += "°Æ";
                break;
            case 9:
                m_str += "¾Á";
                break;
            default:
                break;
        }

        return m_str;

    }
    private string ConvertDec(string m_part)
    {
        string m_str;
        int m_val;

        m_str = "";
        m_val = (int)System.Convert.ToInt32(m_part, 10) / 10;
        switch (m_val)
        {
            case 1:
                m_str = "Ò¼½Ç";
                break;

            case 2:
                m_str = "·¡½Ç";
                break;
            case 3:
                m_str = "Èþ½Ç";
                break;
            case 4:
                m_str = "ËÁ½Ç";
                break;
            case 5:
                m_str = "Îé½Ç";
                break;
            case 6:
                m_str = "Â½½Ç";
                break;
            case 7:
                m_str = "Æâ½Ç";
                break;

            case 8:
                m_str = "°Æ½Ç";
                break;
            case 9:
                m_str = "¾Á½Ç";
                break;
            default:
                break;

        }

        m_val = (int)System.Convert.ToInt32(m_part, 10) % 10;

        switch (m_val)
        {
            case 1:
                m_str += "Ò¼·Ö";
                break;

            case 2:
                m_str += "·¡·Ö";
                break;
            case 3:
                m_str += "Èþ·Ö";
                break;
            case 4:
                m_str += "ËÁ·Ö";
                break;
            case 5:
                m_str += "Îé·Ö";
                break;
            case 6:
                m_str += "Â½·Ö";
                break;
            case 7:
                m_str += "Æâ·Ö";
                break;

            case 8:
                m_str += "°Æ·Ö";
                break;
            case 9:
                m_str += "¾Á·Ö";
                break;
            default:
                break;

        }


        return m_str;
    }
}