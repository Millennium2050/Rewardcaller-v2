function generateRandomSearchText() {
    // Array of random search keywords related to cryptocurrency and .NET technologies
    var cryptoKeywords = [
        "cryptocurrency news",
        "blockchain technology",
        "Bitcoin latest updates",
        "Ethereum development guide",
        "crypto trading strategies",
        "DeFi projects overview",
        "NFT marketplace analysis",
        "smart contracts tutorial",
        "crypto security best practices"
        // Add more relevant keywords as needed
    ];

    // Array of random search keywords related to .NET technologies
    var dotnetKeywords = [
        ".NET Core performance optimization",
        "C# latest features",
        "ASP.NET MVC best practices",
        "Azure DevOps CI/CD pipeline setup",
        "Entity Framework Core migration guide",
        "Visual Studio Code extensions for .NET developers",
        "Blazor web development tutorial",
        "Azure Functions deployment steps",
        "Dockerizing .NET applications"
        // Add more relevant keywords as needed
    ];

    // Randomly select either crypto or dotnet keywords
    var randomCategory = Math.random() < 0.5 ? "crypto" : "dotnet";

    // Choose random keyword from the selected category
    var randomIndex;
    var randomKeyword;
    if (randomCategory === "crypto") {
        randomIndex = Math.floor(Math.random() * cryptoKeywords.length);
        randomKeyword = cryptoKeywords[randomIndex];
    } else {
        randomIndex = Math.floor(Math.random() * dotnetKeywords.length);
        randomKeyword = dotnetKeywords[randomIndex];
    }
    debugger
    // Return the random search keyword
    return randomKeyword;
}



function changeSearchTextAndSearch(newSearchText) {
    // Find the search input field
    var searchInput = document.getElementById('sb_form_q');
    debugger
    // Check if the search input field exists
    if (searchInput) {
        // Change the value of the search input
        searchInput.value = newSearchText;

        // Find the search button
        var searchButton = document.querySelector('input[type="submit"][value="Search"]');
        
        // Check if the search button exists
        if (searchButton) {
            // Trigger a click event on the search button
            searchButton.click();
        } else {
            console.error("Search button not found.");
        }
    } else {
        console.error("Search input field not found.");
    }
}


function triggerSearchEvery10Seconds() {
    // Initial trigger
    // changeSearchTextAndSearch(generateRandomSearchText());
	debugger
    // Set interval to trigger every 10 seconds
    setInterval(function() {
        changeSearchTextAndSearch(generateRandomSearchText());
    }, 10000); // 10000 milliseconds = 10 seconds
}

