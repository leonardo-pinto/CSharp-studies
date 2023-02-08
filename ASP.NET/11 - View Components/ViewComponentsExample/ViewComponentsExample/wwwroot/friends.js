document.querySelector("#load-friends-button")
    .addEventListener("click", async () => {
        var response = await fetch("/load-friends-list", { method: "GET" })
        var content = await response.text();
        document.querySelector("#list").innerHTML = content;
    });