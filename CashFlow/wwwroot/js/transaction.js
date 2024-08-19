window.addEventListener('load', function () {
    BindTransactionCRUDControls();
});


function BindTransactionCRUDControls() {
    BindTransactionSave();
    BindTransactionEdit();
    BindTransactionDelete();
    BindTransactionCreate();
    BindTransactionClose();
}

function BindTransactionSave() {
    let submitBtn = $('#addTransaction')[0];
    submitBtn.addEventListener('click', function () {
        PostTransaction();
    })
}

function BindTransactionEdit() {
    let editBtnList = document.querySelectorAll("[id='editTransaction']");
    for (let i = 0; i < editBtnList.length; i++) {
        editBtnList[i].addEventListener('click', function () {
            EditTransaction(editBtnList[i].getAttribute('data-custom-id'));
        });
    }
}

function BindTransactionDelete() {
    let deleteBtnList = document.querySelectorAll("[id='deleteTransaction']");
    for (let i = 0; i < deleteBtnList.length; i++) {
        deleteBtnList[i].addEventListener('click', function () {
            DeleteTransaction(deleteBtnList[i].getAttribute('data-custom-id'));
        });
    }
}

function BindTransactionCreate() {
    let createBtn = $('#createTransaction')[0];
    createBtn.addEventListener('click', function () {
        clearModalValues();
        $('#exampleModal').modal('show');
    });
}

function BindTransactionClose() {
    let closeBtn = $('#closeTransaction')[0];
    closeBtn.addEventListener('click', function () {
        $('#exampleModal').modal('hide');
    })
}



function PostTransaction() {
    let description = document.querySelector("[name=description]").value;
    let amount = document.querySelector("[name=amount]").value;
    let type = document.querySelector("[name=transactiontype]").value;
    let id = document.querySelector("[name=id]").value;
    if (description == null || amount == null || type == null) {
        window.alert('You must enter all data.');
        return;
    }

    const transactionData = {
        ID: id == null ? 0 : id, Description: description, Amount: amount,
        TransactionType: type === "Expense" ? 0 : 1 // 0 for Expense, 1 for Income
    };

    $.ajax({
        async: false,
        type: "Post",
        url: '/Transaction/SaveTransaction',
        data: JSON.stringify(transactionData),
        contentType: "application/json",
        dataType: 'html',
        success: function (response) {
            $('#exampleModal').modal('hide');
            location.reload();
        },
        error: function (request, textStatus, errorThrown) {
            success = false;
            console.error(request.responseText, request.status);
        }
    });
}

function DeleteTransaction(dataID) {
    const dataToPost = { ID: dataID };
    $.ajax({
        async: false,
        type: "Post",
        url: '/Transaction/DeleteTransaction',
        data: JSON.stringify(dataToPost),
        contentType: "application/json",
        dataType: 'html',
        success: function () {
            location.reload();
        },
        error: function (request, textStatus, errorThrown) {
            success = false;
            console.error(request.responseText, request.status);
        }
    });
}

function EditTransaction(dataID) {
    setModalValues(dataID);
    $('#exampleModal').modal('show');
}

function setModalValues(dataID) {
    document.querySelector("[name=description]").value = $('#' + `${dataID}desc`)[0].textContent.trim();
    document.querySelector("[name=amount]").value = $('#' + `${dataID}amount`)[0].textContent.trim();
    document.querySelector("[name=transactiontype]").value = $('#' + `${dataID}tt`)[0].textContent.trim();
    document.querySelector("[name=id]").value = dataID;
}

function clearModalValues() {
    document.querySelector("[name=description]").value = "";
    document.querySelector("[name=amount]").value = null;
    document.querySelector("[name=transactiontype]").value = null;
    document.querySelector("[name=id]").value = 0;
}
