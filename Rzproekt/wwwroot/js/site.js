"use strict";



var appHome = new Vue({
    el: '#appHome',
    data: {
        date: new Date().getFullYear(),
        blocksServices: '',
        aboutTxtTextarea: '',
        aboutDetailTxtTextarea: '',
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
            '/api/footer/get-footer',
            '/api/back-office/get-certs'
        ],
        general: {
            detailse: 'Подробнее'
        },
        header: [],
        service: [],
        about: [],
        cert: [],
        stat: [],
        project: [],
        client: [],
        contact: [],
        footer: []
    },
    //created() {
        
    //},
        
    // После загрузки страницы вызывает функцию _getData для всех блоков сайта
    mounted: function () {
        this.$nextTick(function () {
            let self = this;
            let ageCompanyTxt = +JSON.stringify(this.$data.date - 1938).slice('1');
            this.$data.ageCompanyTxt = this.declination(ageCompanyTxt, 'ГОД', 'ГОДА', 'ЛЕТ') + " НА РЫНКЕ";
            let allREquest = this.$data.listRequests;
            allREquest.forEach(function (el) {
                self._getData(el);
            });
            appHome.$data.blocksServices = document.getElementsByClassName("serviceTxt");
            appHome.$data.aboutTxtTextarea = document.getElementsByClassName("aboutTxtTextarea");
            appHome.$data.aboutDetailTxtTextarea = document.getElementsByClassName("aboutDetailTxtTextarea");
        })
    },
    methods: {
        getBlocksSevices() {
            autosize(this.blocksServices);
            autosize(this.aboutTxtTextarea);
            autosize(this.aboutDetailTxtTextarea);
            $('[data-fancybox="gallery"]').fancybox({
                selector: '.imglist a:visible'
            });
            $('.single-slide').slick({
                infinite: true,
                dots: true
            });
            $('.multiple-items').slick({
                dots: true,
                infinite: false,
                speed: 300,
                slidesToShow: 5,
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
                        breakpoint: 800,
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
                            case 'cert':
                                self.$data.cert = response.data;
                                console.log('cert получены', response.data);
                                break
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
        smoothScroll(event) {
            var $anchor = event.target;
            $('html, body').stop().animate({
                scrollTop: $($anchor.getAttribute('href')).offset().top - 100
            }, 1000);
            event.preventDefault();
            this.getBlocksSevices(); //запускает автосайз
            this.projectsJs(); //запускает блок прокты
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
        },
        projectsJs() {
            $('[data-fancybox^="quick-view"]').fancybox({
                animationEffect: "fade",
                animationDuration: 300,
                margin: 0,
                gutter: 0,
                touch: {
                    vertical: false
                },
                baseTpl:
                    '<div class="fancybox-container" role="dialog" tabindex="-1">' +
                    '<div class="fancybox-bg"></div>' +
                    '<div class="fancybox-inner">' +
                    '<div class="fancybox-stage"></div>' +
                    '<div class="fancybox-form-wrap">' +
                    '<button data-fancybox-close class="fancybox-button fancybox-button--close" title="{{CLOSE}}">' +
                    '<img src="./img/close.png" />' +
                    '</button></div>' +
                    '</div>' +
                    '</div>',
                onInit: function (instance) {
                    var current = instance.group[instance.currIndex];
                    instance.$refs.form = current.opts.$orig.parent().find('.product-form');
                    instance.$refs.form.appendTo(instance.$refs.container.find('.fancybox-form-wrap'));
                    var list = '',
                        $bullets;

                    for (var i = 0; i < instance.group.length; i++) {
                        list += '<li><a data-index="' + i + '" href="javascript:;"><span>' + (i + 1) + '</span></a></li>';
                    }

                    $bullets = $('<ul class="product-bullets">' + list + '</ul>').on('click touchstart', 'a', function () {
                        var index = $(this).data('index');

                        $.fancybox.getInstance(function () {
                            this.jumpTo(index);
                        });

                    });

                    instance.$refs.bullets = $bullets.appendTo(instance.$refs.stage);

                },
                beforeShow: function (instance) {
                    instance.$refs.stage.find('ul:first')
                        .children()
                        .removeClass('active')
                        .eq(instance.currIndex)
                        .addClass('active');
                },
                afterClose: function (instance, current) {
                    instance.$refs.form.appendTo(current.opts.$orig.parent());
                }
            });
        }
    }
});
window.addEventListener('wheel', event => {
    appHome.getBlocksSevices();
    appHome.projectsJs();
    //$("#waterwheel-carousel").waterwheelCarousel({
    //    horizon: 110,
    //    horizonOffset: -50,
    //    horizonOffsetMultiplier: .7,
    //    separation: 150,
    //    edgeFadeEnabled: true
    //});
});