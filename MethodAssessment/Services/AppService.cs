namespace MethodAssessment.Services;

public class AppService
{
    public Task<string[]> GenerateUniqueStrings(int size = 1000, int page = 1)
    {
        if (page <= 0)
            throw new ArgumentException("Page number must be positive.", nameof(page));
        if (size <= 0)
            throw new ArgumentException("Page size must be positive.", nameof(size));
        if (size > 100000)
            throw new ArgumentException("Page size is too large. Maximum allowed is 100,000.", nameof(size));
        const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        var random = new Random(0); // Using a seed for deterministic results
        var allStrings = new HashSet<string>();

        int totalStringsNeeded = page * size;

        if (totalStringsNeeded > 238328) // 62^3, maximum possible unique combinations
            throw new ArgumentException("Requested page is beyond the maximum possible unique combinations.");

        while (allStrings.Count < totalStringsNeeded)
        {
            char[] str = new char[3];
            for (int i = 0; i < 3; i++)
            {
                str[i] = characters[random.Next(characters.Length)];
            }

            allStrings.Add(new string(str));
        }

        return Task.FromResult(allStrings.Skip((page - 1) * size).Take(size).ToArray());
    }
}