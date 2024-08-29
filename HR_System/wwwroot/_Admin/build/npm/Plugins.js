const Plugins = [
  // jQuery
  {
    from: 'node_modules/jquery/dist',
    to  : '~/_Admin/plugins/jquery'
  },
  // Popper
  {
    from: 'node_modules/popper.js/dist',
    to  : '~/_Admin/plugins/popper'
  },
  // Bootstrap
  {
    from: 'node_modules/bootstrap/~/_Admin/dist/js',
    to  : '~/_Admin/plugins/bootstrap/js'
  },
  // Font Awesome
  {
    from: 'node_modules/@fortawesome/fontawesome-free/css',
    to  : '~/_Admin/plugins/fontawesome-free/css'
  },
  {
    from: 'node_modules/@fortawesome/fontawesome-free/webfonts',
    to  : '~/_Admin/plugins/fontawesome-free/webfonts'
  },
  // overlayScrollbars
  {
    from: 'node_modules/overlayscrollbars/js',
    to  : '~/_Admin/plugins/overlayScrollbars/js'
  },
  {
    from: 'node_modules/overlayscrollbars/css',
    to  : '~/_Admin/plugins/overlayScrollbars/css'
  },
  // Chart.js
  {
    from: 'node_modules/chart.js/~/_Admin/dist/',
    to  : '~/_Admin/plugins/chart.js'
  },
  // jQuery UI
  {
    from: 'node_modules/jquery-ui-~/_Admin/dist/',
    to  : '~/_Admin/plugins/jquery-ui'
  },
  // Flot
  {
    from: 'node_modules/flot/~/_Admin/dist/es5/',
    to  : '~/_Admin/plugins/flot'
  },
  // Summernote
  {
    from: 'node_modules/summernote/~/_Admin/dist/',
    to  : '~/_Admin/plugins/summernote'
  },
  // Bootstrap Slider
  {
    from: 'node_modules/bootstrap-slider/~/_Admin/dist/',
    to  : '~/_Admin/plugins/bootstrap-slider'
  },
  {
    from: 'node_modules/bootstrap-slider/~/_Admin/dist/css',
    to  : '~/_Admin/plugins/bootstrap-slider/css'
  },
  // Bootstrap Colorpicker
  {
    from: 'node_modules/bootstrap-colorpicker/~/_Admin/dist/js',
    to  : '~/_Admin/plugins/bootstrap-colorpicker/js'
  },
  {
    from: 'node_modules/bootstrap-colorpicker/~/_Admin/dist/css',
    to  : '~/_Admin/plugins/bootstrap-colorpicker/css'
  },
  // Tempusdominus Bootstrap 4
  {
    from: 'node_modules/tempusdominus-bootstrap-4/build/js',
    to  : '~/_Admin/plugins/tempusdominus-bootstrap-4/js'
  },
  {
    from: 'node_modules/tempusdominus-bootstrap-4/build/css',
    to  : '~/_Admin/plugins/tempusdominus-bootstrap-4/css'
  },
  // Moment
  {
    from: 'node_modules/moment/min',
    to  : '~/_Admin/plugins/moment'
  },
  {
    from: 'node_modules/moment/locale',
    to  : '~/_Admin/plugins/moment/locale'
  },
  // FastClick
  {
    from: 'node_modules/fastclick/lib',
    to  : '~/_Admin/plugins/fastclick'
  },
  // Date Range Picker
  {
    from: 'node_modules/daterangepicker/',
    to  : '~/_Admin/plugins/daterangepicker'
  },
  // DataTables
  {
    from: 'node_modules/pdfmake/build',
    to: '~/_Admin/plugins/pdfmake'
  },
  {
    from: 'node_modules/jszip/dist',
    to: '~/_Admin/plugins/jszip'
  },
  {
    from: 'node_modules/datatables.net/js',
    to: '~/_Admin/plugins/datatables'
  },
  {
    from: 'node_modules/datatables.net-bs4/js',
    to: '~/_Admin/plugins/datatables-bs4/js'
  },
  {
    from: 'node_modules/datatables.net-bs4/css',
    to: '~/_Admin/plugins/datatables-bs4/css'
  },
  {
    from: 'node_modules/datatables.net-autofill/js',
    to: '~/_Admin/plugins/datatables-autofill/js'
  },
  {
    from: 'node_modules/datatables.net-autofill-bs4/js',
    to: '~/_Admin/plugins/datatables-autofill/js'
  },
  {
    from: 'node_modules/datatables.net-autofill-bs4/css',
    to: '~/_Admin/plugins/datatables-autofill/css'
  },
  {
    from: 'node_modules/datatables.net-buttons/js',
    to: '~/_Admin/plugins/datatables-buttons/js'
  },
  {
    from: 'node_modules/datatables.net-buttons-bs4/js',
    to: '~/_Admin/plugins/datatables-buttons/js'
  },
  {
    from: 'node_modules/datatables.net-buttons-bs4/css',
    to: '~/_Admin/plugins/datatables-buttons/css'
  },
  {
    from: 'node_modules/datatables.net-colreorder/js',
    to: '~/_Admin/plugins/datatables-colreorder/js'
  },
  {
    from: 'node_modules/datatables.net-colreorder-bs4/js',
    to: '~/_Admin/plugins/datatables-colreorder/js'
  },
  {
    from: 'node_modules/datatables.net-colreorder-bs4/css',
    to: '~/_Admin/plugins/datatables-colreorder/css'
  },
  {
    from: 'node_modules/datatables.net-fixedcolumns/js',
    to: '~/_Admin/plugins/datatables-fixedcolumns/js'
  },
  {
    from: 'node_modules/datatables.net-fixedcolumns-bs4/js',
    to: '~/_Admin/plugins/datatables-fixedcolumns/js'
  },
  {
    from: 'node_modules/datatables.net-fixedcolumns-bs4/css',
    to: '~/_Admin/plugins/datatables-fixedcolumns/css'
  },
  {
    from: 'node_modules/datatables.net-fixedheader/js',
    to: '~/_Admin/plugins/datatables-fixedheader/js'
  },
  {
    from: 'node_modules/datatables.net-fixedheader-bs4/js',
    to: '~/_Admin/plugins/datatables-fixedheader/js'
  },
  {
    from: 'node_modules/datatables.net-fixedheader-bs4/css',
    to: '~/_Admin/plugins/datatables-fixedheader/css'
  },
  {
    from: 'node_modules/datatables.net-keytable/js',
    to: '~/_Admin/plugins/datatables-keytable/js'
  },
  {
    from: 'node_modules/datatables.net-keytable-bs4/js',
    to: '~/_Admin/plugins/datatables-keytable/js'
  },
  {
    from: 'node_modules/datatables.net-keytable-bs4/css',
    to: '~/_Admin/plugins/datatables-keytable/css'
  },
  {
    from: 'node_modules/datatables.net-responsive/js',
    to: '~/_Admin/plugins/datatables-responsive/js'
  },
  {
    from: 'node_modules/datatables.net-responsive-bs4/js',
    to: '~/_Admin/plugins/datatables-responsive/js'
  },
  {
    from: 'node_modules/datatables.net-responsive-bs4/css',
    to: '~/_Admin/plugins/datatables-responsive/css'
  },
  {
    from: 'node_modules/datatables.net-rowgroup/js',
    to: '~/_Admin/plugins/datatables-rowgroup/js'
  },
  {
    from: 'node_modules/datatables.net-rowgroup-bs4/js',
    to: '~/_Admin/plugins/datatables-rowgroup/js'
  },
  {
    from: 'node_modules/datatables.net-rowgroup-bs4/css',
    to: '~/_Admin/plugins/datatables-rowgroup/css'
  },
  {
    from: 'node_modules/datatables.net-rowreorder/js',
    to: '~/_Admin/plugins/datatables-rowreorder/js'
  },
  {
    from: 'node_modules/datatables.net-rowreorder-bs4/js',
    to: '~/_Admin/plugins/datatables-rowreorder/js'
  },
  {
    from: 'node_modules/datatables.net-rowreorder-bs4/css',
    to: '~/_Admin/plugins/datatables-rowreorder/css'
  },
  {
    from: 'node_modules/datatables.net-scroller/js',
    to: '~/_Admin/plugins/datatables-scroller/js'
  },
  {
    from: 'node_modules/datatables.net-scroller-bs4/js',
    to: '~/_Admin/plugins/datatables-scroller/js'
  },
  {
    from: 'node_modules/datatables.net-scroller-bs4/css',
    to: '~/_Admin/plugins/datatables-scroller/css'
  },
  {
    from: 'node_modules/datatables.net-select/js',
    to: '~/_Admin/plugins/datatables-select/js'
  },
  {
    from: 'node_modules/datatables.net-select-bs4/js',
    to: '~/_Admin/plugins/datatables-select/js'
  },
  {
    from: 'node_modules/datatables.net-select-bs4/css',
    to: '~/_Admin/plugins/datatables-select/css'
  },

  // Fullcalendar
  {
    from: 'node_modules/@fullcalendar/core/',
    to  : '~/_Admin/plugins/fullcalendar'
  },
  {
    from: 'node_modules/@fullcalendar/bootstrap/',
    to  : '~/_Admin/plugins/fullcalendar-bootstrap'
  },
  {
    from: 'node_modules/@fullcalendar/daygrid/',
    to  : '~/_Admin/plugins/fullcalendar-daygrid'
  },
  {
    from: 'node_modules/@fullcalendar/timegrid/',
    to  : '~/_Admin/plugins/fullcalendar-timegrid'
  },
  {
    from: 'node_modules/@fullcalendar/interaction/',
    to  : '~/_Admin/plugins/fullcalendar-interaction'
  },
  // icheck bootstrap
  {
    from: 'node_modules/icheck-bootstrap/',
    to  : '~/_Admin/plugins/icheck-bootstrap'
  },
  // inputmask
  {
    from: 'node_modules/inputmask/~/_Admin/dist/',
    to  : '~/_Admin/plugins/inputmask'
  },
  // ion-rangeslider
  {
    from: 'node_modules/ion-rangeslider/',
    to  : '~/_Admin/plugins/ion-rangeslider'
  },
  // JQVMap (jqvmap-novulnerability)
  {
    from: 'node_modules/jqvmap-novulnerability/~/_Admin/dist/',
    to  : '~/_Admin/plugins/jqvmap'
  },
  // jQuery Mapael
  {
    from: 'node_modules/jquery-mapael/js/',
    to  : '~/_Admin/plugins/jquery-mapael'
  },
  // Raphael
  {
    from: 'node_modules/raphael/',
    to  : '~/_Admin/plugins/raphael'
  },
  // jQuery Mousewheel
  {
    from: 'node_modules/jquery-mousewheel/',
    to  : '~/_Admin/plugins/jquery-mousewheel'
  },
  // jQuery Knob
  {
    from: 'node_modules/jquery-knob-chif/~/_Admin/dist/',
    to  : '~/_Admin/plugins/jquery-knob'
  },
  // pace-progress
  {
    from: 'node_modules/@lgaitan/pace-progress/~/_Admin/dist/',
    to  : '~/_Admin/plugins/pace-progress'
  },
  // Select2
  {
    from: 'node_modules/select2/~/_Admin/dist/',
    to  : '~/_Admin/plugins/select2'
  },
  {
    from: 'node_modules/@ttskch/select2-bootstrap4-theme/~/_Admin/dist/',
    to  : '~/_Admin/plugins/select2-bootstrap4-theme'
  },
  // Sparklines
  {
    from: 'node_modules/sparklines/source/',
    to  : '~/_Admin/plugins/sparklines'
  },
  // SweetAlert2
  {
    from: 'node_modules/sweetalert2/~/_Admin/dist/',
    to  : '~/_Admin/plugins/sweetalert2'
  },
  {
    from: 'node_modules/@sweetalert2/theme-bootstrap-4/',
    to  : '~/_Admin/plugins/sweetalert2-theme-bootstrap-4'
  },
  // Toastr
  {
    from: 'node_modules/toastr/build/',
    to  : '~/_Admin/plugins/toastr'
  },
  // jsGrid
  {
    from: 'node_modules/jsgrid/dist',
    to: '~/_Admin/plugins/jsgrid'
  },
  {
    from: 'node_modules/jsgrid/demos/',
    to: '~/_Admin/plugins/jsgrid/demos'
  },
  // flag-icon-css
  {
    from: 'node_modules/flag-icon-css/css',
    to: '~/_Admin/plugins/flag-icon-css/css'
  },
  {
    from: 'node_modules/flag-icon-css/flags',
    to: '~/_Admin/plugins/flag-icon-css/flags'
  },
  // bootstrap4-duallistbox
  {
    from: 'node_modules/bootstrap4-duallistbox/dist',
    to: '~/_Admin/plugins/bootstrap4-duallistbox/'
  },
  // filterizr
  {
    from: 'node_modules/filterizr/dist',
    to: '~/_Admin/plugins/filterizr/'
  },
  // ekko-lightbox
  {
    from: 'node_modules/ekko-lightbox/dist',
    to: '~/_Admin/plugins/ekko-lightbox/'
  },

  // AdminLTE Dist
  {
    from: '~/_Admin/dist/css',
    to  : 'docs/assets/css'
  },
  {
    from: '~/_Admin/dist/js',
    to  : 'docs/assets/js'
  },
  // jQuery
  {
    from: 'node_modules/jquery/dist',
    to  : 'docs/assets/~/_Admin/plugins/jquery'
  },
  // Popper
  {
    from: 'node_modules/popper.js/dist',
    to  : 'docs/assets/~/_Admin/plugins/popper'
  },
  // Bootstrap
  {
    from: 'node_modules/bootstrap/~/_Admin/dist/js',
    to  : 'docs/assets/~/_Admin/plugins/bootstrap/js'
  },
  // Font Awesome
  {
    from: 'node_modules/@fortawesome/fontawesome-free/css',
    to  : 'docs/assets/~/_Admin/plugins/fontawesome-free/css'
  },
  {
    from: 'node_modules/@fortawesome/fontawesome-free/webfonts',
    to  : 'docs/assets/~/_Admin/plugins/fontawesome-free/webfonts'
  },
  // overlayScrollbars
  {
    from: 'node_modules/overlayscrollbars/js',
    to  : 'docs/assets/~/_Admin/plugins/overlayScrollbars/js'
  },
  {
    from: 'node_modules/overlayscrollbars/css',
    to  : 'docs/assets/~/_Admin/plugins/overlayScrollbars/css'
  }
]

module.exports = Plugins
