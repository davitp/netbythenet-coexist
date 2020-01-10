FROM adoptopenjdk/openjdk11:alpine-jre
RUN mkdir -p /opt/supplier

EXPOSE 33011

COPY target/supplier.jar /opt/supplier

ENTRYPOINT exec java $JAVA_OPTS -jar /opt/supplier/supplier.jar

