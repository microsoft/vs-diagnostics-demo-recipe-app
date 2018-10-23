var maxIngredientID = 0;
var maxInstructionID = 0;

function deleteIngredientRow(row) {
    var tableSize = document.getElementById('ingredientsTable').rows.length;
    if (tableSize > 2) {
        var i = row.parentNode.parentNode.rowIndex;
        document.getElementById('ingredientsTable').deleteRow(i);
    }
}

function deleteInstructionRow(row) {
    var table = document.getElementById('instructionsTable');
    var rowCount = table.rows.length;

    if (rowCount > 2) {
        var i = row.parentNode.parentNode.rowIndex;
        document.getElementById('instructionsTable').deleteRow(i);
        rowCount--;
        
        for (var j = 1; j <= rowCount; j++) {
            var r = table.rows[j];
            r.cells[0].innerHTML = '<td>' + j + '</td>';
        }
    }
}

function addIngredientRow(row) {
    var newRowIndex = row.parentNode.parentNode.rowIndex + 1;
    var table = document.getElementById("ingredientsTable");
    var newRow = table.insertRow(newRowIndex);

    newRow.innerHTML = newRow.innerHTML.replace(/{id}/, ++maxIngredientID);

    var cell1 = newRow.insertCell(0);
    var cell2 = newRow.insertCell(1);
    var cell3 = newRow.insertCell(2);

    cell1.innerHTML = '<td><input class="form-control" asp-for="ExtendedIngredients" /></td>';
    cell2.innerHTML = '<td><button type="button" class="btn btn-success" onclick="addIngredientRow(this)">+</button></td>';
    cell3.innerHTML = '<td><button type="button" class="btn btn-danger" onclick="deleteIngredientRow(this)">-</button></td>';
}

function addInstructionRow(row) {
    var newRowIndex = row.parentNode.parentNode.rowIndex + 1;
    var table = document.getElementById("instructionsTable");
    var rowCount = table.rows.length;
    var newRow = table.insertRow(newRowIndex);

    newRow.innerHTML = newRow.innerHTML.replace(/{id}/, ++maxInstructionID);

    // instruction step cell
    newRow.insertCell(0);

    // modify steps
    for (var i = 1; i <= rowCount; i++) {
        var r = table.rows[i];
        r.cells[0].innerHTML = '<td>' + i + '</td>';
    }

    var cell1 = newRow.insertCell(1);
    var cell2 = newRow.insertCell(2);
    var cell3 = newRow.insertCell(3);

    cell1.innerHTML = '<td><input class="form-control" asp-for="AnalyzedInstructions[0].Steps" /></td>';
    cell2.innerHTML = '<td><button type="button" class="btn btn-success" onclick="addInstructionRow(this)">+</button></td>';
    cell3.innerHTML = '<td><button type="button" class="btn btn-danger" onclick="deleteInstructionRow(this)">-</button></td>';
}


