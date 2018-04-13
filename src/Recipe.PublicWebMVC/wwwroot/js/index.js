(function () {
    $(document).ready(function () {
        $.getJSON("http://localhost:64407/api/recipes/?limit=9", function (data) {
            var cardContainer = $("#cardContainer");

            if (!data) {
                return;
            }

            $.each(data, function (key, recipe) {
                var html = "";

                html += "<div class='col-md-4'>";
                html += "    <div class='card mb-4 box-shadow'>";
                html += "       <img class='card-img-top' src='" + recipe.image + "' alt='Image of " + recipe.title + "'>";
                html += "       <div class='card-body'>";
                html += "           <p class='card-text'>" + recipe.title + "</p>";
                html += "           <div class='d-flex justify-content-between align-items-center'>";
                html += "               <small class='text-muted'>from " + recipe.sourceName + "</small>";
                html += "               <small class='text-muted'><strong>" + recipe.readyInMinutes + " mins</strong></small>";
                
                html += "           </div>";
                html += "           <div class='d-flex justify-content-between align-items-center'>";
                html += "               <small class='text-muted'>Rating: " + recipe.spoonacularScore + "%</small>";
                html += "           </div>";
                html += "       </div>";
                html += "    </div>";
                html += "</div>";

                cardContainer.append(html);
            });
        });
    });
})();