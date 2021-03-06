﻿window.showUpsert = function(id, divScope, urlToGo, jqGridToUse) {
    var scope = angular.element($(divScope)).scope();
    scope.show({ id: id }, urlToGo).
        then(function () { $(jqGridToUse).trigger("reloadGrid"); });

};

window.showConfirmService = function (id, divScope, urlToGo, jqGridToUse) {
    var scope = angular.element($(divScope)).scope();
    scope.doConfirm({ id: id }, urlToGo).
        then(function () { $(jqGridToUse).trigger("reloadGrid"); });
};


window.showConfirmCancelDocument = function (id, folio, divScope, urlToGo, jqGridToUse) {
    var scope = angular.element($(divScope)).scope();
    scope.doCancelDocument({ uuid: id }, urlToGo, folio).
        then(function () { $(jqGridToUse).trigger("reloadGrid"); });
};

window.showObsolete = function (id, divScope, urlToGo, jqGridToUse) {
    var scope = angular.element($(divScope)).scope();
    scope.doObsolete({ id: id }, urlToGo).
        then(function () { $(jqGridToUse).trigger("reloadGrid"); });
};

window.showModalFormDlg = function(divModalid, formId) {
    var dlgCat = $(divModalid);
    dlgCat.modal('show');

    $.validator.unobtrusive.parse(formId);

    $(divModalid).injector().invoke(function ($compile, $rootScope) {
        $compile($(divModalid))($rootScope);
        $rootScope.$apply();
    });

    var scope = angular.element(dlgCat).scope();
    scope.setDlg(dlgCat);
};

window.goToUrlMvcUrl = function (url, params) {

    for (var key in params) {
        var param = params[key] || '';
        url = url.replace(key, param);
    }

    try {
        window.location.replace(url);
    } catch (e) {
        window.location = url;
    }
};

window.sendPostAction = function(id, divScope, urlToGo, innerScp, showSuccess) {
    var scope = angular.element($(divScope)).scope();
    scope.sendPostAction({ id: id }, urlToGo, innerScp, showSuccess);
};

window.goToUrlMvcUrl = function (url, params) {
    if (params !== undefined) {
        for (var key in params) {
            var param = params[key] || '';
            url = url.replace(key, param);
        }
    }

    try {
        window.location.replace(url);
    } catch (e) {
        window.location = url;
    }
};

window.firstCatalog = function (catalog, id, param) {
    for (var i = 0, len = catalog.length; i < len; i++) {
        var item = catalog[i];
        if (item.Id == id) {
            if (param === undefined) {
                return item.ValOne;
            }
            return item[param];
        }
    }
    return "ND";
};


window.fullCatalog = function (catalog, id) {
    var lstData = [];
    for (var i = 0, len = catalog.length; i < len; i++) {
        var item = catalog[i];
        if (item.Id == id) {
            lstData.push(item);
        }
    }
    return lstData;
};

