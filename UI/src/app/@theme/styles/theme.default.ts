export const DEFAULT_THEME = {
  name: 'default',
  base: null,
  variables: {

    // Safari fix
    temperature: [
      '#EE3B24',
      '#EE3B24',
      '#EE3B24',
      '#EE3B24',
      '#EE3B24',
    ],

    solar: {
      gradientLeft: '#EE3B24',
      gradientRight: '#EE3B24',
      shadowColor: 'rgba(0, 0, 0, 0)',
      radius: ['80%', '90%'],
    },

    traffic: {
      colorBlack: '#000000',
      tooltipBg: '#ffffff',
      tooltipBorderColor: '#c0c8d1',
      tooltipExtraCss: 'border-radius: 10px; padding: 4px 16px;',
      tooltipTextColor: '#2a2a2a',
      tooltipFontWeight: 'bolder',

      lineBg: '#c0c8d1',
      lineShadowBlur: '1',
      itemColor: '#bcc3cc',
      itemBorderColor: '#bcc3cc',
      itemEmphasisBorderColor: '#EE3B24',
      shadowLineDarkBg: 'rgba(0, 0, 0, 0)',
      shadowLineShadow: 'rgba(0, 0, 0, 0)',
      gradFrom: '#ebeef2',
      gradTo: '#ebeef2',
    },

    electricity: {
      tooltipBg: '#ffffff',
      tooltipLineColor: 'rgba(0, 0, 0, 0)',
      tooltipLineWidth: '0',
      tooltipBorderColor: '#ebeef2',
      tooltipExtraCss: 'border-radius: 10px; padding: 8px 24px;',
      tooltipTextColor: '#2a2a2a',
      tooltipFontWeight: 'bolder',

      axisLineColor: 'rgba(0, 0, 0, 0)',
      xAxisTextColor: '#2a2a2a',
      yAxisSplitLine: '#ebeef2',

      itemBorderColor: '#EE3B24',
      lineStyle: 'solid',
      lineWidth: '4',
      lineGradFrom: '#EE3B24',
      lineGradTo: '#EE3B24',
      lineShadow: 'rgba(0, 0, 0, 0)',

      areaGradFrom: 'rgba(235, 238, 242, 0.5)',
      areaGradTo: 'rgba(235, 238, 242, 0.5)',
      shadowLineDarkBg: 'rgba(0, 0, 0, 0)',
    },

    bubbleMap: {
      titleColor: '#484848',
      areaColor: '#dddddd',
      areaHoverColor: '#cccccc',
      areaBorderColor: '#ebeef2',
    },

    echarts: {
      bg: '#ffffff',
      textColor: '#484848',
      axisLineColor: '#bbbbbb',
      splitLineColor: '#ebeef2',
      itemHoverShadowColor: 'rgba(0, 0, 0, 0.5)',
      tooltipBackgroundColor: '#6a7985',
      areaOpacity: '0.7',
    },

    chartjs: {
      axisLineColor: '#cccccc',
      textColor: '#484848',
    },
  },
};
