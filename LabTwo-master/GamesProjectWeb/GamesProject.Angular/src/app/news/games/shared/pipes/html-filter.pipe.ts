import {Pipe, PipeTransform} from '@angular/core';

@Pipe({
  name: 'appHtmlFilter'
})

export  class HtmlFilterPipe implements  PipeTransform {

  transform(value: string): string {
    return  value.replace(/<\/?[^>]+>/g, '');
  }

}
