using Newtonsoft.Json;
using Questao2;

public class Program
{
    public static async Task Main()
    {
        string teamName = "Paris Saint-Germain";
        int year = 2013;
        int totalGoals = await getTotalScoredGoalsAsync(teamName, year);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        teamName = "Chelsea";
        year = 2014;
        totalGoals = await getTotalScoredGoalsAsync(teamName, year);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year); 
    }

    private static async Task<int> getTotalScoredGoalsAsync(string team, int year)
    {
        int totalScoredGoals = 0;
        int pageNumber = 1;
        int totalPages = 1; 

        for (int teamPosition = 1; teamPosition <= 2; teamPosition++)
        {
            try
            {
                while (pageNumber <= totalPages)
                {
                    string url = $"https://jsonmock.hackerrank.com/api/football_matches?team{teamPosition}={team}&year={year}&page={pageNumber}";

                    using (HttpClient client = new HttpClient())
                    {
                        HttpResponseMessage response = await client.GetAsync(url);
                        string responseBody = await response.Content.ReadAsStringAsync();

                        if (!response.IsSuccessStatusCode)
                        {
                            throw new Exception($"Erro: {response.StatusCode}");
                        }

                        var result = JsonConvert.DeserializeObject<Information>(responseBody);
                        totalPages = result.total_pages;
                        totalScoredGoals = countTeamGoals(totalScoredGoals, result, teamPosition);

                        pageNumber++;
                    }
                }
                pageNumber = 1;
                totalPages = 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}"); 
                throw;
            }
        }

        return totalScoredGoals;
    }

    private static int countTeamGoals(int totalScoredGoals, Information? result, int numberTeam)
    {
        if (numberTeam == 1)
        {
            totalScoredGoals += result.data.Sum(g => int.Parse(g.team1goals));
        }
        else
        {
            totalScoredGoals += result.data.Sum(g => int.Parse(g.team2goals));
        } 
        return totalScoredGoals;
    }
}