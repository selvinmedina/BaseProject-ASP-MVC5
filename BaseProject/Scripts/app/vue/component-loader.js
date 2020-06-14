var MyComponets = new Vue({
    el: '#main',
    template: `<div><p>{{saludo}}</p></div>`,
    data: function () {
        return {
            // Saludar
            saludo: 'Hola mundo',
        }
    }
});