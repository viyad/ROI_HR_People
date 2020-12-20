<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:template match="/">
<html> 
<body>
  <h1>Department</h1>
  <table class="small-table">
    <tr>
	  <th>Id</th>
      <th width="90%">Name</th>
    </tr>
    <xsl:for-each select="departments/department">
    <tr>
	  <td><xsl:value-of select="./@id"/></td>
      <td><xsl:value-of select="name"/></td>
    </tr>
    </xsl:for-each>
  </table>
</body>
</html>
</xsl:template>
</xsl:stylesheet>

