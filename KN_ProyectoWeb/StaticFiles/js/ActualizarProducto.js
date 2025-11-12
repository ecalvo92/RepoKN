$(function () {

    $("#FormActualizarProducto").validate({
        rules: {
            Nombre: {
                required: true
            },
            Descripcion: {
                required: true
            },
            Precio: {
                required: true,
                decimal: true
            },
            ConsecutivoCategoria: {
                required: true
            },
            ImgProducto: {
                extension: "png",
                filesize: 2 * 1024 * 1024 // 2 MB en bytes
            }
        },
        messages: {
            Nombre: {
                required: "* Requerido",
            },
            Descripcion: {
                required: "* Requerido",
            },
            Precio: {
                required: "* Requerido",
                decimal: "* Ingrese un número válido"
            },
            ConsecutivoCategoria: {
                required: "* Requerido",
            },
            ImgProducto: {
                extension: "Solo se permiten archivos .png",
                filesize: "El tamaño máximo es de 2 MB"
            }
        }
    });

    $.validator.addMethod("filesize", function (value, element, param) {
        if (element.files.length === 0) {
            return true;
        }
        return element.files[0].size <= param;
    }, "El archivo es demasiado grande.");

    $.validator.addMethod("extension", function (value, element, param) {
        if (!value) {
            return true;
        }
        return new RegExp("\\.(" + param + ")$", "i").test(value);
    }, "Formato de archivo no permitido.");

    $.validator.addMethod("decimal", function (value, element) {
        return this.optional(element) || /^\d+(\,\d{1,2})?$/.test(value);
    }, "Ingrese un número válido (use solo un punto decimal).");

});