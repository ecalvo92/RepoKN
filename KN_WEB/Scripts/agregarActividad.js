function previsualizarImagen(input)
{
  if (!input.files || !input.files[0])
    return;

  var reader = new FileReader();
  reader.onload = function (e)
  {
    document.getElementById('previstaImagen').src = e.target.result;
    document.getElementById('previstaImagen').classList.remove('d-none');
    document.getElementById('textoImagen').classList.add('d-none');
    document.getElementById('zonaImagen').classList.add('sin-borde');
  };

  reader.readAsDataURL(input.files[0]);
}