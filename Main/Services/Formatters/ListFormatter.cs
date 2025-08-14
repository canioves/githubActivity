using System.Text;

namespace Main.Services.Formatters
{
    public static class ListFormatter
    {
        public static string ToBulletList(
            IEnumerable<string> items,
            string bullet = "-",
            int indentCount = 2
        )
        {
            StringBuilder sb = new StringBuilder();

            foreach (string item in items)
            {
                string indent = new string(' ', indentCount);
                sb.AppendLine($"{indent}{bullet} {item}");
            }

            return sb.ToString();
        }
    }
}
