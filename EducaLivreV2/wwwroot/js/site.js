// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// Codexino fica feliz quando encontra resultados!
function codexinoBuscaFeliz(resultados) {
    const codexino = document.getElementById('codexinoScrollTop');
    if (!codexino || !resultados) return;

    // Pisca os olhos rapidamente (animação CSS)
    codexino.style.animation = 'codexino-piscar 0.3s 2';

    setTimeout(() => {
        codexino.style.animation = '';
    }, 600);
}

// Adicione no CSS:
@keyframes codexino - piscar {
    0 %, 100 % { opacity: 1; }
    50 % { opacity: 0.7; transform: scale(0.95); }
}

// Quando o usuário rola para ver resultados da busca
window.addEventListener('scroll', function () {
    const codexino = document.getElementById('codexinoScrollTop');
    if (!codexino) return;

    const scrollPosition = window.scrollY;
    const resultadosSection = document.querySelector('.cards');

    if (resultadosSection && scrollPosition > resultadosSection.offsetTop - 100) {
        // Codexino fica "observando" os resultados
        codexino.classList.add('codexino-observando');
    } else {
        codexino.classList.remove('codexino-observando');
    }
});

