"use strict";

//window.addEventListener("hashchange", function (e) {
//    //document.getElementById('o').innerHTML = e.oldURL;
//    //document.getElementById('n').innerHTML = e.newURL;
//	console.log("test");
//}, false);

//$(window).bind('hashchange', function () {
//    console.log("test");
//});

//if (location.href.includes("#") || location.href.includes("/")) {
//    console.log("test");
//}

//if ("onhashchange" in window) {
//    alert("The browser supports the hashchange event!");
//}

var appHome = new Vue({
    el: '#appHome',
    data: {
        date: new Date().getFullYear(),
        urlApi: 'https://localhost:44349',
        listRequests: [
            '/api/header/get-header',
            '/api/order/get-orders',
            '/api/about/get-about',
            '/api/statistic/get-statistic',
            '/api/project/get-projects',
            '/api/client/get-clients',
            '/api/contact/get-contacts',
            '/api/footer/get-footer'
        ],
        general: {
            detailse: 'Подробнее'
        },
        header: [],
        service: [],
        about: [],
        stat: [],
        project: [],
        client: [],
        contact: [],
        footer: []
    },
    update: {

    },
    created() {
        console.log('init');
        
        
    },
    // После загрузки страницы вызывает функцию _getData для всех блоков сайта
    mounted: function () {
        this.$nextTick(function () {
            let self = this;
            let allREquest = this.$data.listRequests;
            allREquest.forEach(function (el) {
                self._getData(el);
            })
            
        })
    },
    methods: {
        //  Функция выгружает все данные
        _getData(url) {
            let self = this;
            let sUrl = self.$data.urlApi + url;
            
            try {
                axios.post(sUrl)
                    .then((response) => {
                        switch (response.data[0].block) {
                            case 'header':
                                self.$data.header = response.data;
                                console.log('header получен', response.data);
                                break;
                            case 'service':
                                self.$data.service = response.data;
                                console.log('service получен', response.data);
                                break;
                            case 'about':
                                self.$data.about = response.data;
                                console.log('about получен', response.data);
                                break;
                            case 'stat':
                                self.$data.stat = response.data;
                                console.log('stat получен', response.data);
                                break;
                            case 'project':
                                self.$data.project = response.data;
                                console.log('project получен', response.data);
                                break;
                            case 'client':
                                self.$data.client = response.data;
                                console.log('client получен', response.data);
                                break;
                            case 'contact':
                                self.$data.contact = response.data;
                                console.log('contact получен', response.data);
                                break;
                            case 'footer':
                                self.$data.footer = response.data;
                                console.log('footer получен', response.data);
                                break;

                        }
                        
                    })
                    .catch((XMLHttpRequest) => {
                        throw new Error(XMLHttpRequest);
                    });
            }
            catch (ex) {
                throw new Error(ex);
            }
        },
        smoothScroll() {
            $('.block-nav a, #home a').on('click', function (event) {
                var $anchor = $(this);
                $('html, body').stop().animate({
                    scrollTop: $($anchor.attr('href')).offset().top - 49
                }, 1000);
                event.preventDefault();
            });
        }  
    }
});
