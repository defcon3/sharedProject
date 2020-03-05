<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:output method="xml"/>
  <xsl:decimal-format decimal-separator="," grouping-separator="."/>
  <xsl:template match="/MarketCatalogue">
    <wurzel>
      <xsl:apply-templates/>
    </wurzel>
  </xsl:template>
  <xsl:template match="result">
    <xsl:for-each select="//MarketCatalogue/result/runners">
      <runners>
        <marketId>
          <xsl:value-of select="//MarketCatalogue/result/marketId"/>
        </marketId>
        <marketName>
          <xsl:value-of select="//MarketCatalogue/result/marketName"/>
        </marketName>
        <totalMatched>
          <xsl:value-of select="//MarketCatalogue/result/totalMatched"/>
        </totalMatched>
        <id>
          <xsl:value-of select="//MarketCatalogue/result/eventType/id"/>
        </id>
        <name>
          <xsl:value-of select="//MarketCatalogue/result/eventType/name"/>
        </name>
        <selectionId>
          <xsl:value-of select="translate(selectionId,',', '.')"/>
        </selectionId>
        <runnerName>
          <xsl:value-of select="runnerName"/>
        </runnerName>
        <handicap>
          <xsl:value-of select="handicap"/>
        </handicap>
        <sortPriority>
          <xsl:value-of select="sortPriority"/>
        </sortPriority>
      </runners>
    </xsl:for-each>
    <xsl:for-each select="//MarketCatalogue/result">
      <runners>
        <marketId>
          <xsl:value-of select="//MarketCatalogue/result/marketId"/>
        </marketId>
        <marketName>
          <xsl:value-of select="//MarketCatalogue/result/marketName"/>
        </marketName>
        <totalMatched>
          <xsl:value-of select="//MarketCatalogue/result/totalMatched"/>
        </totalMatched>
        <runnerName>
          <xsl:value-of select="runnerName"/>
        </runnerName>
        <handicap>
          <xsl:value-of select="handicap"/>
        </handicap>
        <sortPriority>
          <xsl:value-of select="sortPriority"/>
        </sortPriority>
      </runners>
    </xsl:for-each>
  </xsl:template>
</xsl:stylesheet>