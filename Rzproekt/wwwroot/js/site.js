"use strict";

var appHome = new Vue({
    el: '#appHome',
    data: {
        aHeader: [],
        header: {
            //logo: '~/img/logo.png',
            nav: {
                main: 'Главная',
                service: 'Услуги',
                project: 'Проекты',
                about: 'О нас',
                contacts: 'Контакты'
            }
        }
    },
    //update: {

    //},
    created() {
        console.log('init');
        this._getLogo();
    },
    methods: {
        // Функция получает лого.
        _getLogo() {
            let sUrl = "https://localhost:44349/api/header/get-header";
            
            try {
                axios.post(sUrl)
                    .then((response) => {
                        console.log("Лого получен", response.data);
                        this.aHeader = response.data;
                    })
                    .catch((XMLHttpRequest) => {
                        throw new Error(XMLHttpRequest.response.data);
                    });
            }
            catch (ex) {
                throw new Error(ex);
            }
		}
    }
});
