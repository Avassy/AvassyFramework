# Avassy.NetCore.Global.Attributes

See [http://www.avassy.com/framework/components/Avassy.NetCore.Global.Extensions](http://www.avassy.com/framework/components/Avassy.NetCore.Global.Attributes) for more info.

## Classes

- `Avassy.NetCore.Global.Attributes.EmailAddressExtendedAttribute`
- `Avassy.NetCore.Global.Attributes.UrlExtendedAttribute`

## Usage

### `EmailAddressExtendedAttribute`

This validation attribute validates email addresses with the following regex:

``^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$``


### `UrlExtendedAttribute`

This validation attribute validates URLs with the following regex:

``((([A-Za-z]{3,9}:(?:\/\/)?)(?:[\-;:&=\+\$,\w]+@)?[A-Za-z0-9\.\-]+|(?:www\.|[\-;:&=\+\$,\w]+@)[A-Za-z0-9\.\-]+)((?:\/[\+~%\/\.\w\-_]*)?\??(?:[\-\+=&;%@\.\w_]*)#?(?:[\.\!\/\\\w]*))?)``

