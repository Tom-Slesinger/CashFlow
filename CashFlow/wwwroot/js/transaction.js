window.addEventListener('load', function () {
    //Bind Lisnters
    BindTransactionSubmit();
});


function Bind() {

}

function BindTransactionSubmit() {
    let submitBtn = $('#addTransaction')[0];
    console.log(submitBtn);
    submitBtn.addEventListener('click', function () {
        PostTransaction();
    })
}


function PostTransaction() {
    let description = document.querySelector("[name=description]").value;
    let amount = document.querySelector("[name=amount]").value;
    let type = document.querySelector("[name=transactiontype]").value;
    if (description == null || amount == null || type == null) {
        window.alert('You must enter all data.');
        return;
    }

    const transactionData = {
        ID: 0, Description: description, Amount: amount,
        TransactionType: type === "Expense" ? 0 : 1 // 0 for Expense, 1 for Income
    };
    console.log(transactionData);
    let success = true;
    $.ajax({
        async: false,
        type: "Post",
        url: '/Transaction/SaveTransaction',
        data: JSON.stringify(transactionData),
        contentType: "application/json",
        dataType: 'html',
        success: function (response) {
            window.alert('Data Saved!');
            $('#exampleModal').modal('hide');
        },
        error: function (request, textStatus, errorThrown) {
            success = false;
            console.error(request.responseText, request.status);
        }
    });

    if (success === true) {
        $('#exampleModal').modal('hide');
    }
}