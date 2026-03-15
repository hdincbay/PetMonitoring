document.addEventListener("DOMContentLoaded", function () {
    const deleteButtons = document.querySelectorAll(".delete-button");
    const deleteModalEl = document.getElementById('deleteModal');
    const deleteModal = new bootstrap.Modal(deleteModalEl);

    const deleteIdInput = document.getElementById("deleteIdInput");
    const deleteNameInput = document.getElementById("deleteNameInput");
    const deletePetNameInput = document.getElementById("deletePetNameInput");
    const deleteSerialInput = document.getElementById("deleteSerialInput");
    const deleteIsDeletedInput = document.getElementById("deleteIsDeletedInput");
    const deleteDeletedDateInput = document.getElementById("deleteDeletedDateInput");
    const modalBodyText = document.getElementById("modalBodyText");

    deleteButtons.forEach(button => {
        button.addEventListener("click", function () {
            const deviceId = this.dataset.id;
            const deviceName = this.dataset.name;
            const devicePetName = this.dataset.petname;
            const deviceSerial = this.dataset.serial;
            const deviceIsDeleted = this.dataset.isdeleted;
            const deviceDeletedDate = this.dataset.deleteddate;

            deleteIdInput.value = deviceId;
            deleteNameInput.value = deviceName;
            deletePetNameInput.value = devicePetName;
            deleteSerialInput.value = deviceSerial;
            deleteIsDeletedInput.value = deviceIsDeleted;
            deleteDeletedDateInput.value = deviceDeletedDate;

            modalBodyText.textContent = `'${deviceName}' isimli cihazı silmek istediğinize emin misiniz?`;

            deleteModal.show();
        });
    });
});