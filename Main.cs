using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSubRip
{
    public static class Decoder
    {
        public static List<SubRipParagraph> DecodeToObject(string str)
        {
            bool parsingParagraph = false;
            bool parsingTime = false;

            string[] lines = str.Split('\n');

            int currentID = -1;
            float currentStartSeconds = -1;
            float currentEndSeconds = -1;
            string text = "";

            List<SubRipParagraph> paragraphs = new List<SubRipParagraph>();

            for (int lineID=0; lineID < lines.Length; lineID++)
            {
                parsingTime = false;
                if (int.TryParse(lines[lineID], out int n))
                {
                    if (currentID == -1)
                    {
                        currentID = int.Parse(lines[lineID]);
                        parsingParagraph = true;
                    }
                }

                if (parsingParagraph)
                {
                    string[] splittedTimes = lines[lineID].Split('>');
                    if (splittedTimes.Length == 2)
                    {
                        parsingTime = true;
                        foreach (string time in splittedTimes)
                        {
                            string betterLine = time.RemoveWhitespace().Split('-')[0];
                            string[] generalTime = betterLine.Split(',')[0].Split(':');
                            float ms = float.Parse(betterLine.Split(',')[1]);

                            if (currentStartSeconds == -1)
                            {
                                currentStartSeconds = 0;
                                currentStartSeconds += float.Parse(generalTime[0].RemoveWhitespace()) * 3600;
                                currentStartSeconds += float.Parse(generalTime[1].RemoveWhitespace()) * 60;
                                currentStartSeconds += float.Parse(generalTime[2].RemoveWhitespace());

                                string msStr = ms.ToString();
                                for (int i=0; i < msStr.Length; i++)
                                    ms /= 10;

                                currentStartSeconds += ms;
                            }
                            else if (currentEndSeconds == -1)
                            {
                                currentEndSeconds = 0;
                                currentEndSeconds += float.Parse(generalTime[0].RemoveWhitespace()) * 3600;
                                currentEndSeconds += float.Parse(generalTime[1].RemoveWhitespace()) * 60;
                                currentEndSeconds += float.Parse(generalTime[2].RemoveWhitespace());

                                string msStr = ms.ToString();
                                for (int i = 0; i < msStr.Length; i++)
                                    ms /= 10;

                                currentEndSeconds += ms;
                            }
                        }
                    }

                    if (!parsingTime && currentStartSeconds != -1 && currentEndSeconds != -1)
                        text += lines[lineID] + (lines.Length >= lineID + 2 && lines[lineID + 1] != "" ? "\n" : "");
                }

                if (lines[lineID] == "" || lineID == lines.Length - 1)
                {
                    SubRipParagraph newParagraph = new SubRipParagraph();
                    newParagraph.id = currentID;
                    newParagraph.startSeconds = currentStartSeconds;
                    newParagraph.endSeconds = currentEndSeconds;
                    newParagraph.text = text;

                    paragraphs.Add(newParagraph);

                    currentID = -1;
                    currentStartSeconds = -1;
                    currentEndSeconds = -1;
                    text = "";

                    parsingParagraph = false;
                }
            }

            return paragraphs;
        }

        public static string RemoveWhitespace(this string input)
        {
            if (input == null) return null;
            return string.Concat(input.Split(null));
        }
    }

    [Serializable]
    public class SubRipParagraph
    {
        public int id;
        public float startSeconds;
        public float endSeconds;
        public string text;
    }
}
