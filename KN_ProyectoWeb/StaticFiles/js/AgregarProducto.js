$(function () {

    $("#FormAgregarProducto").validate({
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
                required: true,
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
                required: "* Requerido",
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
            return false;
        }
        return element.files[0].size <= param;
    }, "El archivo es demasiado grande.");

    $.validator.addMethod("extension", function (value, element, param) {
        return this.optional(element) || new RegExp("\\.(" + param + ")$", "i").test(value);
    }, "Formato de archivo no permitido.");

});