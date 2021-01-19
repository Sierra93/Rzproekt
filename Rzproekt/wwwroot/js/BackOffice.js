"use strict";

var back_office = new Vue({
    el: "#back_office",
    data() {
        return {
            files: '',
            filesService: '',
            filesAbout: '',
            filesCert: '',
            filesAwards: '',
            filesClient: '',
            aboutMainImg: '',
            filesDetAbout: '',
            filesProject: '',
            filesDetProject: '',
            filesContact: '',
            filesContactAdd: '',
            date: new Date().getFullYear(),
            notify: '',
            urlApi: 'https://localhost:44349',
            //urlApi: 'https://rzproekt.ru',
            listRequests: [
                '/api/header/get-header',
                '/api/order/get-orders',
                '/api/about/get-about',
                '/api/statistic/get-statistic',
                '/api/project/get-projects',
                '/api/project/all-projects',
                '/api/client/get-clients',
                '/api/contact/contacts-company',
                '/api/footer/get-footer',
                '/api/back-office/get-certs',
                '/api/contact/contacts-lead'
            ],
            general: {
                detailse: 'Подробнее'
            },
            header: [],
            service: [],
            about: [],
            cert: [],
            arrCertSearth: [],
            arrAwardsSearth: [],
            stat: [],
            project: [],
            arrProject: [],
            client: [],
            arrClientSearth: [],
            contact: [],
            contactLead: [],
            arrContactSearth: [],
            footer: [],
            arrMsgChat: [],
            arrDialogChat: [],
            dialogActiveId: ''
        }
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
            });
            self.onAllProject();
            self.getAllDialog();
            function getMsg() {
                self.getMsgList(sessvars.userId);
            }
            //setInterval(getMsg, 1000);
        })
    },
    methods: {
        getAllDialog() {
            let self = this;
            let sUrl = self.$data.urlApi + '/api/message/dialog-list';
            try {
                axios.post(sUrl)
                    .then((response) => {
                        response.data.forEach(function (el) {
                            el.created = self.formatDateTime(el.created);
                        });
                        self.$data.arrDialogChat = response.data;
                    })
                    .catch((XMLHttpRequest) => {
                        throw new Error(XMLHttpRequest);
                    });
            }
            catch (ex) {
                throw new Error(ex);
            }
        },
        onOpenMsgDialog(e) {
            let self = this;
            let DialogId = +e.target.getAttribute('idCustom');
            let sUrl = this.$data.urlApi + '/api/message/dialog-messages';
            let arrListClient = document.getElementsByClassName('block-user-item');
            for (let item of arrListClient) {
                item.classList.remove('active-msg-user');
            }
            e.target.classList.add('active-msg-user');
            let oData = {
                DialogId
            }
            try {
                axios.post(sUrl, oData)
                    .then((response) => {
                        response.data.forEach(function (el) {
                            el.created = self.formatDateTime(el.created);
                        });
                        self.$data.arrMsgChat = response.data;
                        self.$data.dialogActiveId = DialogId;
                    })
                    .catch((XMLHttpRequest) => {
                        throw new Error(XMLHttpRequest);
                    });
            }
            catch (ex) {
                throw new Error(ex);
            }
        },
        onDelDialog(e) {
            let self = this;
            let DialogId = +e.target.parentNode.getAttribute('idCustom');
            let sUrl = self.$data.urlApi + '/api/message/remove-dialog';

            try {
                axios.get(sUrl + '/' + DialogId)
                    .then((response) => {
                        self.getAllDialog();
                    })
                    .catch((XMLHttpRequest) => {
                        throw new Error(XMLHttpRequest);
                    });
            }
            catch (ex) {
                throw new Error(ex);
            }
        },
        // Функция собирает файлы header.
        handleFilesUpload() {
            let filesLogo = document.getElementById('filesLogo').files[0];
            let filesVideoBgHeader = document.getElementById('filesVideoBgHeader').files[0];

            if (!!filesLogo) {
                this.files = filesLogo;
            } else if (!!filesVideoBgHeader) {
                this.files = filesVideoBgHeader;
            }
        },
        // Функция собирает файлы услуг.
        handleFilesUploadService() {
            let arrBlocksImg = document.getElementsByClassName('form-files-service');
            this.filesService = arrBlocksImg;
        },
        // Функция собирает файлы о нас.
        handleFilesUploadAbout() {
            let arrBlocksImg = document.getElementsByClassName('form-files-about');
            this.aboutMainImg = arrBlocksImg;
        },
        // Функция собирает файлы клиенты.
        handleFilesUploadClient() {
            let arrBlocksImg = document.getElementsByClassName('form-files-client');
            this.filesClient = arrBlocksImg;
        },
        // Функция собирает файлы о нас (детальная информания).
        handleFilesUploadDetAbout() {
            let filesDetAbout = document.getElementsByClassName('form-files-det-about')[0].files[0];
            this.filesDetAbout = filesDetAbout;
        },
        // Функция собирает файлы сертификатов.
        handleFilesUploadCert() {
            let filesCert = document.getElementsByClassName('form-files-cert')[0].files;
            this.filesCert = filesCert;
        },
        // Функция собирает файлы наград.
        handleFilesUploadAwards() {
            let filesAwards = document.getElementsByClassName('form-files-awards')[0].files;
            this.filesAwards = filesAwards;
        },
        // Функция собирает файлы клиентов.
        handleFilesUploadClient() {
            let filesClient = document.getElementsByClassName('form-files-client')[0].files;
            this.filesClient = filesClient;
        },
        handleFilesUploadContact() {
            let filesContact = document.getElementsByClassName('form-files-contact')[0].files;
            this.filesContact = filesContact;
        },
        handleFilesUploadClientAdd() {
            let filesContactAdd = document.getElementsByClassName('form-files-contactAdd')[0].files;
            this.filesContactAdd = filesContactAdd;
        },
        // Функция оповещений результатов запросов.
        notyfi(e) {
            let blockNotify = document.getElementById('notifications');
            if (e) {
                this.notify = "Данные успешно изменены"
                blockNotify.style.backgroundColor = 'green';
                blockNotify.classList.add('notifications-active');
                function hide() {
                    blockNotify.classList.remove('notifications-active');
                }

                setTimeout(hide, 2000);
            } else {
                this.notify = "Ошибка, данные не изменились"
                blockNotify.style.backgroundColor = 'red';
                blockNotify.classList.add('notifications-active');
                function hide() {
                    blockNotify.classList.remove('notifications-active');
                }
                setTimeout(hide, 2000);
            }

        },

        // Отправляет измененные данные первого блока сайта
        onChangeHeader() {
            let self = this;
            let sUrl = self.$data.urlApi + '/api/back-office/change-header';
            let MainItem = $('.header-menu-txt');
            let MainNum = $('.header-menu-num')[0].value;
            let formData = new FormData();

            //formData = formData.get('filesLogo');
            let mainItemArr = [];
            for (let item of MainItem) {
                mainItemArr.push(item.value)
            }

            let MainTitle = $('.header-menu-title')[0].value;

            let oData = {
                MainItem: mainItemArr,
                MainTitle,
                MainNum
            };

            formData.set('filesLogo', this.files);
            formData.set('jsonString', JSON.stringify(oData));

            try {
                axios.post(sUrl, formData)
                    .then((response) => {
                        self.notyfi(true);
                    })
                    .catch((XMLHttpRequest) => {
                        self.notyfi(false);
                        throw new Error(XMLHttpRequest);
                    });
            }
            catch (ex) {
                throw new Error(ex);
            }
        },
        // Отправляет измененные данные блока Услуги
        onChangeService(e) {
            let self = this;
            let sUrl = self.$data.urlApi + '/api/back-office/change-order';
            let idService = +e.target.getAttribute('idCustom') - 1;
            let OrderId = idService + 1;
            let MainTitle = $('.service-main-title')[0].value;
            let Title = $('.service-title')[OrderId - 1].value;
            let Text = $('.service-text')[OrderId - 1].value;


            let formData = new FormData();
            let oData = {
                OrderId,
                MainTitle,
                Title,
                Text
            };
            if (!!this.filesService[idService]) {
                formData.set('filesLogo', this.filesService[idService].files[0]);
            }
            formData.set('jsonString', JSON.stringify(oData));

            try {
                axios.post(sUrl, formData)
                    .then((response) => {
                        self.notyfi(true);

                    })
                    .catch((XMLHttpRequest) => {
                        self.notyfi(false);
                    });
            }
            catch (ex) {
                throw new Error(ex);
            }
        },
        // Отправляет измененные данные блока о нас
        onChangeAbout(e) {
            let self = this;
            let sUrl = self.$data.urlApi + '/api/back-office/change-about';
            let MainTitle = $('.about-Maintitle')[0].value;
            let Text = $('.about-text')[0].value;
            
            let idService = +e.target.getAttribute('idCustom') - 1;
            let Id = idService + 1;
            let formData = new FormData();
            let oData = {
                Id,
                MainTitle,
                Text
            };
            if (!!this.aboutMainImg) {
                formData.set('filesAbout', this.aboutMainImg[0].files[0]);
            } else {
                this.aboutMainImg = '';
            }
            
            formData.set('jsonString', JSON.stringify(oData));

            try {
                axios.post(sUrl, formData)
                    .then((response) => {
                        self.notyfi(true);

                    })
                    .catch((XMLHttpRequest) => {
                        self.notyfi(false);
                    });
            }
            catch (ex) {
                throw new Error(ex);
            }
        },
        onChangeDetAbout(e) {
            let self = this;
            let sUrl = self.$data.urlApi + '/api/back-office/change-detail-about';
            let detMainTitle = $('.about-Det-Maintitle')[0].value;
            let detTitle = $('.about-DetTitle')[0].value;
            let detText = $('.about-detail-text')[0].value;
            let idService = +e.target.getAttribute('idCustom') - 1;
            let Id = idService + 1;
            let formData = new FormData();

            let oData = {
                Id,
                detMainTitle,
                detTitle,
                detText
            };

            if (!!this.filesDetAbout) {
                formData.set('filesDopAbout', this.filesDetAbout);
            } else {
                this.filesDetAbout = '';
            }

            formData.set('jsonString', JSON.stringify(oData));

            try {
                axios.post(sUrl, formData)
                    .then((response) => {
                        self.notyfi(true);

                    })
                    .catch((XMLHttpRequest) => {
                        self.notyfi(false);
                    });
            }
            catch (ex) {
                throw new Error(ex);
            }
        },
        // Поиск Сертификатов
        onSearthCert() {
            let self = this;
            let CertName = document.getElementById("searchCert").value;
            if (!CertName) { self.$data.arrCertSearth = []; return }
            let sUrl = self.$data.urlApi + '/api/about/search';
            let oData = {
                CertName
            };
            axios.post(sUrl, oData)
                .then((response) => {
                    if (!response.data) { self.$data.arrCertSearth = []; return }
                    self.$data.arrCertSearth = response.data;
                    console.log("success / getCert", response);
                })
                .catch((XMLHttpRequest) => {
                    self.notyfi(false);
                });
        },
        // Удаление сертификатов
        onDelCert(e) {
            let self = this;
            let sUrl = self.$data.urlApi + '/api/back-office/remove-cert';
            let idCert = +e.target.getAttribute('idCustom');

            try {
                axios.get(sUrl + '/' + idCert)
                    .then((response) => {
                        self.onSearthCert();
                        self.notyfi(true);

                    })
                    .catch((XMLHttpRequest) => {
                        self.notyfi(false);
                    });
            }
            catch (ex) {
                throw new Error(ex);
            }
        },
        // Добавление сертификатов
        onAddCert() {
            let self = this;
            let sUrl = self.$data.urlApi + '/api/back-office/add-cert';
            let nameCert = document.getElementById("nameCert").value;
            let formData = new FormData();
            let oData = {
                nameCert
            }
            if (!!this.filesCert) {
                formData.set('filesCert', this.filesCert[0]);
            }
            formData.set('jsonString', JSON.stringify(oData));
            try {
                axios.post(sUrl, formData)
                    .then((response) => {
                        self.notyfi(true);

                    })
                    .catch((XMLHttpRequest) => {
                        self.notyfi(false);
                    });
            }
            catch (ex) {
                throw new Error(ex);
            }
        },

        // Поиск Наград
        onSearthAwards() {
            let self = this;
            let AwardName = document.getElementById("searchAwards").value;
            if (!AwardName) { self.$data.arrAwardsSearth = []; return }
            let sUrl = self.$data.urlApi + '/api/about/search-award';
            let oData = {
                AwardName
            };
            axios.post(sUrl, oData)
                .then((response) => {
                    if (!response.data) { self.$data.arrAwardsSearth = []; return }
                    self.$data.arrAwardsSearth = response.data;
                    console.log("success / getAwards", response);
                })
                .catch((XMLHttpRequest) => {
                });
        },
        onDelAwards(e) {
            let self = this;
            let sUrl = self.$data.urlApi + '/api/back-office/remove-award';
            let idAwards = +e.target.getAttribute('idCustom');

            try {
                axios.get(sUrl + '/' + idAwards)
                    .then((response) => {
                        self.onSearthAwards();
                        self.notyfi(true);

                    })
                    .catch((XMLHttpRequest) => {
                        self.notyfi(false);
                    });
            }
            catch (ex) {
                throw new Error(ex);
            }
        },
        // Добавление наград
        onAddAwards() {
            let self = this;
            let sUrl = self.$data.urlApi + '/api/back-office/add-award';
            let nameAwards = document.getElementById("nameAwards").value;
            let formData = new FormData();
            let oData = {
                nameAwards
            }
            if (!!this.filesAwards) {
                formData.set('filesAwards', this.filesAwards[0]);
            }
            formData.set('jsonString', JSON.stringify(oData));
            try {
                axios.post(sUrl, formData)
                    .then((response) => {
                        self.notyfi(true);

                    })
                    .catch((XMLHttpRequest) => {
                        self.notyfi(false);
                    });
            }
            catch (ex) {
                throw new Error(ex);
            }
        },

        // Изменение блока статистики
        onChangeStat() {
            let self = this;
            let sUrl = self.$data.urlApi + '/api/back-office/change-stat';
            let nOne = $('.stat-menu-number-one')[0].value;
            let sOne = $('.stat-menu-txt-one')[0].value;
            let nTwo = $('.stat-menu-number-two')[0].value;
            let sTwo = $('.stat-menu-txt-two')[0].value;
            let nThree = $('.stat-menu-number-three')[0].value;
            let sThree = $('.stat-menu-txt-three')[0].value;

            let oData = {
                nOne,
                sOne,
                nTwo,
                sTwo,
                nThree,
                sThree
            }
            //oData = JSON.stringify(oData);
            try {
                axios.post(sUrl, oData)
                    .then((response) => {
                        self.notyfi(true);

                    })
                    .catch((XMLHttpRequest) => {
                        self.notyfi(false);
                    });
            }
            catch (ex) {
                throw new Error(ex);
            }
        },

        // Все проекты
        onAllProject(e) {
            let self = this;
            let sUrl = self.$data.urlApi + '/api/project/all-projects';

            axios.post(sUrl)
                .then((response) => {
                    if (!response.data) { self.$data.AllProject = []; return }
                    self.$data.arrProject = response.data;
                    console.log("success / getAllProject", response);
                })
                .catch((XMLHttpRequest) => {
                    self.notyfi(false);
                });
        },
        // Поиск проектов
        onSearthProject(e) {
            let self = this;
            let projectName = document.getElementsByClassName("project-searth-project").value;
            if (!projectName) { self.onAllProject(); return }
            let sUrl = self.$data.urlApi + '/api/project/search-project';
            let oData = {
                projectName
            };
            axios.post(sUrl, oData)
                .then((response) => {
                    if (!response.data) { self.$data.arrAwardsSearth = []; return }
                    self.$data.arrProject = response.data;
                    console.log("success / getProject", response);
                })
                .catch((XMLHttpRequest) => {
                });
        },
        // Изменение Проектов
        onChangeProject(e) {
            let self = this;
            let sUrl = self.$data.urlApi + '/api/back-office/change-project';
            let targetProject = e.currentTarget.parentNode;
            let MainTitle = $('.project-menu-title')[0].value;
            let buttonText = $('.project-menu-buttonText')[0].value;
            let projectName = targetProject.getElementsByClassName('project-menu-title')[0].value;
            let projectDetail = targetProject.getElementsByClassName('about-detail-text')[0].value;

            let projectMainPage = targetProject.getElementsByClassName('checkOnlyThreeProject')[0].checked;
            let Id = +e.target.getAttribute('idCustom');
            let oData = {
                ProjectId: Id,
                MainTitle,
                ButtonText: buttonText,
                ProjectName: projectName,
                ProjectDetail: projectDetail,
                IsMain: projectMainPage.toString()
            };

            try {
                axios.post(sUrl, oData)
                    .then((response) => {
                        self.notyfi(true);

                    })
                    .catch((XMLHttpRequest) => {
                        self.notyfi(false);
                    });
            }
            catch (ex) {
                throw new Error(ex);
            }

        },
        // Добавление проектов
        onAddProject(e) {
            let self = this;
            let targetProject = e.currentTarget.parentNode;
            let sUrl = self.$data.urlApi + '/api/back-office/add-project';
            let projectName = document.getElementById("nameProject").value;
            let projectDetail = document.getElementById("detailProject").value;
            let isMain = targetProject.getElementsByClassName('checkOnlyThreeProject')[0].checked.toString();
            let formData = new FormData();
            let oData = {
                ProjectName: projectName,
                ProjectDetail: projectDetail,
                IsMain: isMain
            }
            let ins = self.$data.filesDetProject.length;
            for (var x = 0; x < ins; x++) {
                formData.append("filesProject", this.filesDetProject[x]);
            }
            formData.set('jsonString', JSON.stringify(oData));

            try {
                axios.post(sUrl, formData)
                    .then((response) => {
                        console.log('Данные успешно изменены');
                        self.notyfi(true);

                    })
                    .catch((XMLHttpRequest) => {
                        self.notyfi(false);
                    });
            }
            catch (ex) {
                throw new Error(ex);
            }
        },
        // Удаление проектов
        onDelProject(e) {
            let self = this;
            let sUrl = self.$data.urlApi + '/api/back-office/remove-project';
            let idCert = +e.currentTarget.getAttribute('idCustom');

            try {
                axios.get(sUrl + '/' + idCert)
                    .then((response) => {
                        self.notyfi(true);

                    })
                    .catch((XMLHttpRequest) => {
                        self.notyfi(false);
                    });
            }
            catch (ex) {
                throw new Error(ex);
            }
        },

        // Изменение клиентов
        onChangeClient(e) {
            // Отправляет измененные данные блока Client
            let self = this;
            let sUrl = self.$data.urlApi + '/api/back-office/change-client';
            let MainTitle = $('.client-menu-title')[0].value;
            let idService = +e.target.getAttribute('idCustom') - 1;
            let ClientId = idService + 1;
            let formData = new FormData();
            let oData = {
                ClientId,
                MainTitle
            };
            if (!!this.filesService[idService]) {
                formData.set('filesClient', this.filesService[idService].files[0]);
            }

            formData.set('jsonString', JSON.stringify(oData));


            try {
                axios.post(sUrl, formData)
                    .then((response) => {
                        self.notyfi(true);

                    })
                    .catch((XMLHttpRequest) => {
                        self.notyfi(false);
                    });
            }
            catch (ex) {
                throw new Error(ex);
            }
        },

        // Поиск клиентов
        onSearthClient() {
            let self = this;
            let ClientName = document.getElementById("searchClient").value;
            if (!ClientName) { self.$data.arrClientSearth = []; return }
            let sUrl = self.$data.urlApi + '/api/client/search';
            let oData = {
                ClientName
            };
            axios.post(sUrl, oData)
                .then((response) => {
                    if (!response.data) { self.$data.arrClientSearth = []; return }
                    self.$data.arrClientSearth = response.data;
                    console.log("success / getClient", response);
                })
                .catch((XMLHttpRequest) => {
                    self.notyfi(false);
                });
        },

        // Добваление клиентов
        onAddClient() {
            let self = this;
            let sUrl = self.$data.urlApi + '/api/back-office/add-client';
            let nameClient = document.getElementById("nameClient").value;
            let formData = new FormData();
            let oData = {
                nameClient
            }
            if (!!this.filesClient) {
                formData.set('filesClient', this.filesClient[0]);
            }
            formData.set('jsonString', JSON.stringify(oData));
            try {
                axios.post(sUrl, formData)
                    .then((response) => {
                        console.log('Данные успешно изменены');
                        self.notyfi(true);

                    })
                    .catch((XMLHttpRequest) => {
                        self.notyfi(false);
                    });
            }
            catch (ex) {
                throw new Error(ex);
            }
        },

        // Удаление Клиентов
        onDelClient(e) {
            let self = this;
            let sUrl = self.$data.urlApi + '/api/back-office/remove-client';
            let idService = +e.target.getAttribute('idCustom') - 1;
            let ClientId = idService + 1;

            try {
                axios.get(sUrl + '/' + ClientId)
                    .then((response) => {
                        self.notyfi(true);

                    })
                    .catch((XMLHttpRequest) => {
                        self.notyfi(false);
                    });
            }
            catch (ex) {
                throw new Error(ex);
            }
        },
        // Изменение компании
        onChangeContact(e) {
            let self = this;
            let sUrl = self.$data.urlApi + '/api/back-office/change-contact-lead';
            let LeadName = document.getElementsByClassName("contact-lead-name")[0].value;
            let LeadPosition = document.getElementsByClassName("contact-lead-position")[0].value;
            let LeadFax = document.getElementsByClassName("contact-lead-fax")[0].value;
            let LeadNumber = document.getElementsByClassName("contact-lead-number")[0].value;
            let LeadEmail = document.getElementsByClassName("contact-lead-email")[0].value;
            let idService = +e.target.getAttribute('idCustom') - 1;
            let LeadId = idService + 1;
            let formData = new FormData();
            let oData = {
                LeadId,
                LeadName,
                LeadPosition,
                LeadNumber,
                LeadFax,
                LeadEmail
            };
            if (!!this.filesService[idService]) {
                formData.set('filesContact', this.filesService[idService].files[0]);
            }
            formData.set('jsonString', JSON.stringify(oData));

            try {
                axios.post(sUrl, formData)
                    .then((response) => {
                        self.notyfi(true);

                    })
                    .catch((XMLHttpRequest) => {
                        self.notyfi(false);
                    });
            }
            catch (ex) {
                throw new Error(ex);
            }
        },
        // добавление контакта компании
        onAddContact() {
            let self = this;
            let sUrl = self.$data.urlApi + '/api/back-office/add-contact-lead';
            let LeadName = document.getElementsByClassName("add-contact-lead-name")[0].value;
            let LeadPosition = document.getElementsByClassName("add-contact-lead-position")[0].value;
            let LeadFax = document.getElementsByClassName("add-contact-lead-fax")[0].value;
            let LeadNumber = document.getElementsByClassName("add-contact-lead-number")[0].value;
            let LeadEmail = document.getElementsByClassName("add-contact-lead-email")[0].value;
            let formData = new FormData();
            let oData = {
                LeadName,
                LeadPosition,
                LeadNumber,
                LeadFax,
                LeadEmail
            };
            formData.set('filesContact', this.filesContactAdd[0]);
            formData.set('jsonString', JSON.stringify(oData));

            try {
                axios.post(sUrl, formData)
                    .then((response) => {
                        self.notyfi(true);

                    })
                    .catch((XMLHttpRequest) => {
                        self.notyfi(false);
                    });
            }
            catch (ex) {
                throw new Error(ex);
            }
        },
        // изменение контактов компании
        onChangeContactCompany() {
            let self = this;
            let sUrl = self.$data.urlApi + '/api/back-office/change-contact-company';
            let mainTitle = document.getElementsByClassName("contact-company-main-title")[0].value;
            let Title = document.getElementsByClassName("contact-company-title")[0].value;
            let addressCompany = document.getElementsByClassName("contact-company-address")[0].value;
            let emailCompany = document.getElementsByClassName("contact-company-email")[0].value;
            let numberCompany = document.getElementsByClassName("contact-company-number")[0].value;
            let btnText = document.getElementsByClassName("contact-company-btn")[0].value;
            let oData = {
                mainTitle,
                Title,
                addressCompany,
                emailCompany,
                numberCompany,
                btnText
            }

            try {
                axios.post(sUrl, oData)
                    .then((response) => {
                        console.log('Данные успешно изменены');
                        self.notyfi(true);

                    })
                    .catch((XMLHttpRequest) => {
                        self.notyfi(false);
                    });
            }
            catch (ex) {
                throw new Error(ex);
            }
        },
        // Поиск контактов
        onSearthContacts() {
            let self = this;
            let LeadName = document.getElementById("searchContacts").value;
            if (!LeadName) { self.$data.arrContactSearth = []; return }
            let sUrl = self.$data.urlApi + '/api/contact/search';
            let oData = {
                LeadName
            };
            axios.post(sUrl, oData)
                .then((response) => {
                    if (!response.data) { self.$data.arrContactSearth = []; return }
                    self.$data.arrContactSearth = response.data;
                    console.log("success / getContact", response);
                })
                .catch((XMLHttpRequest) => {
                    self.notyfi(false);
                });
        },

        // Удаление контактов
        onDelContact(e) {
            let self = this;
            let sUrl = self.$data.urlApi + '/api/back-office/remove-lead';
            let idContact = +e.target.getAttribute('idCustom');

            try {
                axios.get(sUrl + '/' + idContact)
                    .then((response) => {
                        self.onSearthContacts();
                        self.notyfi(true);

                    })
                    .catch((XMLHttpRequest) => {
                        self.notyfi(false);
                    });
            }
            catch (ex) {
                throw new Error(ex);
            }
        },

        //  Функция выгружает все данные
        _getData(url) {
            let self = this;
            let sUrl = self.$data.urlApi + url;


            try {
                axios.post(sUrl)
                    .then((response) => {
                        if (!response.data) return;
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
                            case 'cert':
                                self.$data.cert = response.data;
                                console.log('cert получен', response.data);
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
                            case 'contact_lead':
                                self.$data.contactLead = response.data;
                                console.log('contactLead получен', response.data);
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
        onSignIn() {
            let self = this;
            let Login = document.getElementById('login').value;
            let Password = document.getElementById('password').value;
            let sUrl = self.$data.urlApi + '/api/auth/signin';
            let oData = {
                Login,
                Password
            };
            try {
                axios.post(sUrl, oData)
                    .then((response) => {
                        if (response.data.access_token) window.location.href = self.$data.urlApi + response.data.url;

                    })
                    .catch((XMLHttpRequest) => {
                        throw new Error(XMLHttpRequest);
                    });
            }
            catch (ex) {
                throw new Error(ex);
            }
        },
        previewFilesUploadProject(e) {
            let filesDetProject = document.getElementsByClassName('form-files-project')[0].files;
            var input = e.target;
            this.filesDetProject = filesDetProject;
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('#image').attr('src', e.target.result);
                };

                reader.readAsDataURL(input.files[0]);
            }
        },
        checkOnlyThreeProject() {
            var chk_arr = document.getElementsByName("chk");
            var chklength = chk_arr.length;
            var tot = 0;
            var i = -1;
            for (let k = 0; k < chklength; k++) {
                if (chk_arr[k].checked) {
                    tot++;
                    if (i < 0) i = k;
                }
                if (tot > 3) { chk_arr[i].checked = false; }
            }
        },
        sendMsgAdmin() {
            let self = this;
            let MessageText = document.getElementById('msgChat').value;
            let sUrl = self.$data.urlApi + "/api/message/send";
            let AdminDialogId = self.$data.dialogActiveId;
            let IsAdmin = 'true';
            let UserCode = 'admin'

            let oData = {
                UserCode,
                MessageText,
                IsAdmin,
                AdminDialogId
            }
            try {
                axios.post(sUrl, oData)
                    .then((response) => {
                        console.log("ok");
                        if (response.data.aMessages) {
                            self.$data.arrMsgChat = response.data.aMessages;
                        }

                    })
                    .catch((XMLHttpRequest) => {
                        console.log("error");
                    });
            }
            catch (ex) {
                throw new Error(ex);
            }
        },
        formatDateTime(par) {
            let parDate = par.split('T')[0];
            let parTime = par.split('T')[1];
            parTime = parTime.split('.')[0];
            parDate = parDate.split('-').reverse().join('-');
            return parDate + ' ' + parTime;
        }
    }
});