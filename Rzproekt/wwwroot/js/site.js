"use strict";

var appHome = new Vue({
    el: '#appHome',
    data: {
        date: new Date().getFullYear(),
        blocksServices: '',
        ageCompanyTxt: '',
        smoothScrollArr: [],
        urlApi: 'https://localhost:44349',
        //urlApi: 'https://devmyprojects24.xyz',
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
    created() {
        console.log('init');
    },
        
    // После загрузки страницы вызывает функцию _getData для всех блоков сайта
    mounted: function () {
        autosize(document.getElementsByClassName("serviceTxt"));
        this.$nextTick(function () {
            let self = this;
            let allREquest = this.$data.listRequests;
            allREquest.forEach(function (el) {
                self._getData(el);
            });
            function sayHi() {
                appHome.$data.blocksServices = document.getElementsByClassName("serviceTxt");
                if (!appHome.$data.blocksServices) return;
                self.getBlocksSevices();
            }
            setTimeout(sayHi, 100);
            let ageCompanyTxt = +JSON.stringify(this.$data.date-1938).slice('1');
            this.$data.ageCompanyTxt = this.declination(ageCompanyTxt, 'ГОД', 'ГОДА', 'ЛЕТ') + " НА РЫНКЕ";
        })
    },
    methods: {
        getBlocksSevices() {
            autosize(this.blocksServices);
            $('[data-fancybox="gallery"]').fancybox({
                selector: '.imglist a:visible'
            });
            $('.multiple-items').slick({
                dots: true,
                infinite: false,
                speed: 300,
                slidesToShow: 4,
                slidesToScroll: 4,
                responsive: [
                    {
                        breakpoint: 1024,
                        settings: {
                            slidesToShow: 3,
                            slidesToScroll: 3,
                            infinite: true,
                            dots: true
                        }
                    },
                    {
                        breakpoint: 600,
                        settings: {
                            slidesToShow: 2,
                            slidesToScroll: 2
                        }
                    },
                    {
                        breakpoint: 480,
                        settings: {
                            slidesToShow: 1,
                            slidesToScroll: 1
                        }
                    }
                ]
            });

        },
        //  Функция выгружает все данные
        _getData(url) {
            let self = this;
            let sUrl = self.$data.urlApi + url;
            
            try {
                axios.post(sUrl)
                    .then((response) => {
                        switch (response.data[0].block) {
                            case 'header':
                                let arrId = ['','#main', '#service', '#about', '#project', '#client', '#contact'];
                                self.$data.header = response.data;
                                self.$data.smoothScrollArr = arrId;
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
            $('.block-nav a').on('click', function (event) {
                var $anchor = $(this);
                $('html, body').stop().animate({
                    scrollTop: $($anchor.attr('href')).offset().top - 100
                }, 1000);
                event.preventDefault();
            });
        },
        declination(number, one, two, five) {
                let n = Math.abs(number);
                n %= 100;
                if (n >= 5 && n <= 20) {
                    return five;
                }
                n %= 10;
                if (n === 1) {
                    return one;
                }
                if (n >= 2 && n <= 4) {
                    return two;
                }
            return five;
        }
    }
});
