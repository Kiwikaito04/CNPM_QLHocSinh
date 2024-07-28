document.addEventListener('DOMContentLoaded', function () {
    var gioiTinhCheckbox = document.getElementById('GioiTinh');
    var gioiTinhLabel = document.getElementById('GioiTinhLabel');

    updateGioiTinhLabel();

    gioiTinhCheckbox.addEventListener('change', function () {
        updateGioiTinhLabel();
    });

    function updateGioiTinhLabel() {
        if (gioiTinhCheckbox.checked) {
            gioiTinhLabel.textContent = 'Nam';
        } else {
            gioiTinhLabel.textContent = 'Nữ';
        }
    }
});