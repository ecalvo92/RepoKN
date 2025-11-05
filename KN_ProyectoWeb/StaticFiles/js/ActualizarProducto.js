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
                number: true,
                min: 0.01,
                regex: /^\d{1,8}(\.\d{1,2})?$/
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
                number: "* Debe ser un número válido",
                min: "* Debe ser un valor positivo",
                regex: "* Máximo 8 dígitos y 2 decimales"
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

    $.validator.addMethod("regex", function (value, element, pattern) {
        return this.optional(element) || pattern.test(value);
    });

    $.validator.addMethod("filesize", function (value, element, param) {
        if (element.files.length === 0) {
            return false; // si no hay archivo, no pasa (porque será requerido)
        }
        return element.files[0].size <= param;
    }, "El archivo es demasiado grande.");

    $.validator.addMethod("extension", function (value, element, param) {
        return this.optional(element) || new RegExp("\\.(" + param + ")$", "i").test(value);
    }, "Formato de archivo no permitido.");

});