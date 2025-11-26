
  function soloNumerosASCII(input, event) {
    // Obtener el código de la tecla presionada
    var charCode = event.which ? event.which : event.keyCode;

    // Permitir solo números (códigos 48 a 57) y teclas especiales (backspace, delete, flechas)
    if (
      (charCode >= 48 && charCode <= 57) || // Números 0-9
      charCode === 8 ||  // Backspace
      charCode === 46 || // Delete
      (charCode >= 37 && charCode <= 40) // Flechas
    ) {
      return true;
    } else {
      event.preventDefault(); // Bloquear otros caracteres
    }
  }