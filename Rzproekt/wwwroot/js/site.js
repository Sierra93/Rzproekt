"use strict";

var appHome = new Vue({
    el: '#appHome',
    data: {
        header: {
            logo: '~/img/logo.png',
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
    },
    methods: {
    }
});
